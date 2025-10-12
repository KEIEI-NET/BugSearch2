"""
BugSearch2 State Manager

GUI状態の永続化と復元
設定、ウィンドウ位置、ジョブ履歴などを管理
"""

import os
import json
import time
from typing import Dict, Any, Optional
from pathlib import Path
from dataclasses import dataclass, asdict


@dataclass
class WindowState:
    """ウィンドウ状態"""
    width: int = 1200
    height: int = 800
    x: Optional[int] = None
    y: Optional[int] = None
    maximized: bool = False


@dataclass
class AppSettings:
    """アプリケーション設定"""
    theme: str = 'dark'  # 'light' or 'dark'
    max_concurrent_jobs: int = 3
    log_buffer_size: int = 10000
    auto_cleanup_hours: int = 24
    notification_enabled: bool = True
    auto_save_enabled: bool = True
    auto_save_interval: int = 300  # 5分


class StateManager:
    """
    GUI状態の永続化

    機能:
    - ウィンドウ状態の保存/復元
    - アプリケーション設定の管理
    - ジョブ履歴の管理
    - 自動保存
    """

    def __init__(self, state_file: str = '.gui_app_state.json'):
        self.state_file = state_file
        self.window_state = WindowState()
        self.app_settings = AppSettings()
        self.job_history: Dict[str, Any] = {}
        self.custom_data: Dict[str, Any] = {}

        # 状態を復元
        self.load_state()

    def load_state(self) -> bool:
        """
        状態ファイルから読み込み

        Returns:
            成功した場合True
        """
        if not os.path.exists(self.state_file):
            print(f"[WARNING] State file not found: {self.state_file}")
            return False

        try:
            with open(self.state_file, 'r', encoding='utf-8') as f:
                data = json.load(f)

            # バージョンチェック
            version = data.get('version', '1.0.0')
            if version != '1.0.0':
                print(f"[WARNING] State file version mismatch: {version}")
                return False

            # ウィンドウ状態復元
            if 'window' in data:
                self.window_state = WindowState(**data['window'])

            # アプリケーション設定復元
            if 'settings' in data:
                self.app_settings = AppSettings(**data['settings'])

            # ジョブ履歴復元
            if 'job_history' in data:
                self.job_history = data['job_history']

            # カスタムデータ復元
            if 'custom' in data:
                self.custom_data = data['custom']

            print(f"[OK] State loaded from: {self.state_file}")
            return True

        except Exception as e:
            print(f"[ERROR] Failed to load state: {e}")
            return False

    def save_state(self) -> bool:
        """
        状態をファイルに保存

        Returns:
            成功した場合True
        """
        try:
            data = {
                'version': '1.0.0',
                'timestamp': time.time(),
                'window': asdict(self.window_state),
                'settings': asdict(self.app_settings),
                'job_history': self.job_history,
                'custom': self.custom_data,
            }

            # 一時ファイルに書き込み
            temp_file = f"{self.state_file}.tmp"
            with open(temp_file, 'w', encoding='utf-8') as f:
                json.dump(data, f, indent=2, ensure_ascii=False)

            # アトミックに置き換え
            if os.path.exists(self.state_file):
                backup_file = f"{self.state_file}.bak"
                os.replace(self.state_file, backup_file)

            os.replace(temp_file, self.state_file)

            print(f"[OK] State saved to: {self.state_file}")
            return True

        except Exception as e:
            print(f"[ERROR] Failed to save state: {e}")
            return False

    # ウィンドウ状態管理

    def get_window_state(self) -> WindowState:
        """ウィンドウ状態を取得"""
        return self.window_state

    def set_window_state(
        self,
        width: Optional[int] = None,
        height: Optional[int] = None,
        x: Optional[int] = None,
        y: Optional[int] = None,
        maximized: Optional[bool] = None
    ):
        """ウィンドウ状態を設定"""
        if width is not None:
            self.window_state.width = width
        if height is not None:
            self.window_state.height = height
        if x is not None:
            self.window_state.x = x
        if y is not None:
            self.window_state.y = y
        if maximized is not None:
            self.window_state.maximized = maximized

    # アプリケーション設定管理

    def get_settings(self) -> AppSettings:
        """アプリケーション設定を取得"""
        return self.app_settings

    def set_setting(self, key: str, value: Any):
        """設定を変更"""
        if hasattr(self.app_settings, key):
            setattr(self.app_settings, key, value)
            print(f"[OK] Setting updated: {key} = {value}")
        else:
            print(f"[WARNING] Unknown setting: {key}")

    def get_setting(self, key: str, default: Any = None) -> Any:
        """設定を取得"""
        return getattr(self.app_settings, key, default)

    # ジョブ履歴管理

    def add_job_history(self, job_id: str, job_info: Dict[str, Any]):
        """ジョブ履歴を追加"""
        self.job_history[job_id] = {
            **job_info,
            'recorded_at': time.time()
        }

    def get_job_history(self, job_id: str) -> Optional[Dict[str, Any]]:
        """ジョブ履歴を取得"""
        return self.job_history.get(job_id)

    def get_all_job_history(self) -> Dict[str, Any]:
        """全ジョブ履歴を取得"""
        return self.job_history

    def clear_job_history(self, before_timestamp: Optional[float] = None):
        """
        ジョブ履歴をクリア

        Args:
            before_timestamp: この時刻より前の履歴を削除（指定しない場合は全削除）
        """
        if before_timestamp is None:
            self.job_history.clear()
            print("[OK] All job history cleared")
        else:
            jobs_to_remove = [
                job_id for job_id, info in self.job_history.items()
                if info.get('recorded_at', 0) < before_timestamp
            ]
            for job_id in jobs_to_remove:
                del self.job_history[job_id]
            print(f"[OK] Cleared {len(jobs_to_remove)} old job history entries")

    def cleanup_old_history(self, max_age_hours: int = 168):
        """
        古いジョブ履歴をクリーンアップ

        Args:
            max_age_hours: この時間より古い履歴を削除（デフォルト: 7日間）
        """
        cutoff_time = time.time() - (max_age_hours * 3600)
        self.clear_job_history(before_timestamp=cutoff_time)

    # カスタムデータ管理

    def set_custom_data(self, key: str, value: Any):
        """カスタムデータを設定"""
        self.custom_data[key] = value

    def get_custom_data(self, key: str, default: Any = None) -> Any:
        """カスタムデータを取得"""
        return self.custom_data.get(key, default)

    def delete_custom_data(self, key: str):
        """カスタムデータを削除"""
        if key in self.custom_data:
            del self.custom_data[key]

    # ユーティリティ

    def export_state(self, export_path: str) -> bool:
        """
        状態をエクスポート

        Args:
            export_path: エクスポート先パス

        Returns:
            成功した場合True
        """
        try:
            data = {
                'version': '1.0.0',
                'exported_at': time.time(),
                'window': asdict(self.window_state),
                'settings': asdict(self.app_settings),
                'job_history': self.job_history,
                'custom': self.custom_data,
            }

            with open(export_path, 'w', encoding='utf-8') as f:
                json.dump(data, f, indent=2, ensure_ascii=False)

            print(f"[OK] State exported to: {export_path}")
            return True

        except Exception as e:
            print(f"[ERROR] Failed to export state: {e}")
            return False

    def import_state(self, import_path: str) -> bool:
        """
        状態をインポート

        Args:
            import_path: インポート元パス

        Returns:
            成功した場合True
        """
        if not os.path.exists(import_path):
            print(f"[ERROR] Import file not found: {import_path}")
            return False

        try:
            with open(import_path, 'r', encoding='utf-8') as f:
                data = json.load(f)

            # バージョンチェック
            version = data.get('version', '1.0.0')
            if version != '1.0.0':
                print(f"[WARNING] Import file version mismatch: {version}")
                return False

            # データを復元
            if 'window' in data:
                self.window_state = WindowState(**data['window'])

            if 'settings' in data:
                self.app_settings = AppSettings(**data['settings'])

            if 'job_history' in data:
                self.job_history = data['job_history']

            if 'custom' in data:
                self.custom_data = data['custom']

            # 保存
            self.save_state()

            print(f"[OK] State imported from: {import_path}")
            return True

        except Exception as e:
            print(f"[ERROR] Failed to import state: {e}")
            return False

    def reset_to_defaults(self):
        """デフォルト設定にリセット"""
        self.window_state = WindowState()
        self.app_settings = AppSettings()
        self.job_history.clear()
        self.custom_data.clear()
        self.save_state()
        print("[OK] State reset to defaults")

    def get_state_size(self) -> int:
        """状態ファイルのサイズを取得（バイト）"""
        if os.path.exists(self.state_file):
            return os.path.getsize(self.state_file)
        return 0

    def get_last_save_time(self) -> Optional[float]:
        """最後に保存した時刻を取得"""
        if not os.path.exists(self.state_file):
            return None

        try:
            with open(self.state_file, 'r', encoding='utf-8') as f:
                data = json.load(f)
            return data.get('timestamp')
        except:
            return None


if __name__ == '__main__':
    # 簡単なテスト
    manager = StateManager('.test_gui_state.json')

    # ウィンドウ状態設定
    manager.set_window_state(width=1600, height=900, maximized=True)

    # 設定変更
    manager.set_setting('theme', 'light')
    manager.set_setting('max_concurrent_jobs', 5)

    # ジョブ履歴追加
    manager.add_job_history('job_001', {
        'name': 'Test Job',
        'status': 'completed',
        'elapsed_time': 120.5
    })

    # カスタムデータ
    manager.set_custom_data('last_tech_stack', 'react')

    # 保存
    manager.save_state()

    # 新しいインスタンスで復元テスト
    manager2 = StateManager('.test_gui_state.json')
    print(f"\nRestored window state: {manager2.get_window_state()}")
    print(f"Restored settings: {manager2.get_settings()}")
    print(f"Restored job history: {manager2.get_all_job_history()}")
    print(f"Custom data: {manager2.get_custom_data('last_tech_stack')}")

    # クリーンアップ
    os.remove('.test_gui_state.json')
