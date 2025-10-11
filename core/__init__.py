"""
BugSearch2 Core Module

技術スタック対応型コード解析システムのコアモジュール
"""

__version__ = "4.1.0"
__author__ = "Master TED"

# UTF-8出力を最初に設定
from .encoding_handler import setup_utf8_output
setup_utf8_output()

from .models import TechStack, ProjectConfig, Rule
from .project_config import load_project_config
from .rule_engine import RuleEngine
from .encoding_handler import (
    read_file_with_fallback,
    write_file_utf8,
    safe_print,
    is_binary_file,
)

__all__ = [
    "TechStack",
    "ProjectConfig",
    "Rule",
    "load_project_config",
    "RuleEngine",
    "read_file_with_fallback",
    "write_file_utf8",
    "safe_print",
    "is_binary_file",
]
