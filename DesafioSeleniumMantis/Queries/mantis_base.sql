-- --------------------------------------------------------
-- Servidor:                     localhost
-- Versão do servidor:           10.6.5-MariaDB-1:10.6.5+maria~focal - mariadb.org binary distribution
-- OS do Servidor:               debian-linux-gnu
-- HeidiSQL Versão:              11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Copiando estrutura do banco de dados para bugtracker
DROP DATABASE IF EXISTS `bugtracker`;
CREATE DATABASE IF NOT EXISTS `bugtracker` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `bugtracker`;

-- Copiando estrutura para tabela bugtracker.mantis_api_token_table
DROP TABLE IF EXISTS `mantis_api_token_table`;
CREATE TABLE IF NOT EXISTS `mantis_api_token_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` int(10) unsigned NOT NULL DEFAULT 0,
  `name` varchar(128) NOT NULL,
  `hash` varchar(128) NOT NULL,
  `date_created` int(10) unsigned NOT NULL DEFAULT 1,
  `date_used` int(10) unsigned NOT NULL DEFAULT 1,
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_user_id_name` (`user_id`,`name`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_api_token_table: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_api_token_table` DISABLE KEYS */;
INSERT INTO `mantis_api_token_table` (`id`, `user_id`, `name`, `hash`, `date_created`, `date_used`) VALUES
	(1, 1, 'Token API', '6c8958a7c999218738c6d8d139db8ad4ee7e56368043b8ff36e767f777e9877c', 1649094981, 1),
	(2, 2, 'Token API', '6c8958a7c999218738c6d8d139db8ad4ee7e56368043b8ff36e767f777e9877c', 1649094981, 1);
/*!40000 ALTER TABLE `mantis_api_token_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_bugnote_table
DROP TABLE IF EXISTS `mantis_bugnote_table`;
CREATE TABLE IF NOT EXISTS `mantis_bugnote_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `bug_id` int(10) unsigned NOT NULL DEFAULT 0,
  `reporter_id` int(10) unsigned NOT NULL DEFAULT 0,
  `bugnote_text_id` int(10) unsigned NOT NULL DEFAULT 0,
  `view_state` smallint(6) NOT NULL DEFAULT 10,
  `note_type` int(11) DEFAULT 0,
  `note_attr` varchar(250) DEFAULT '',
  `time_tracking` int(10) unsigned NOT NULL DEFAULT 0,
  `last_modified` int(10) unsigned NOT NULL DEFAULT 1,
  `date_submitted` int(10) unsigned NOT NULL DEFAULT 1,
  PRIMARY KEY (`id`),
  KEY `idx_bug` (`bug_id`),
  KEY `idx_last_mod` (`last_modified`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_bugnote_table: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_bugnote_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_bugnote_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_bugnote_text_table
DROP TABLE IF EXISTS `mantis_bugnote_text_table`;
CREATE TABLE IF NOT EXISTS `mantis_bugnote_text_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `note` longtext NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_bugnote_text_table: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_bugnote_text_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_bugnote_text_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_bug_file_table
DROP TABLE IF EXISTS `mantis_bug_file_table`;
CREATE TABLE IF NOT EXISTS `mantis_bug_file_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `bug_id` int(10) unsigned NOT NULL DEFAULT 0,
  `title` varchar(250) NOT NULL DEFAULT '',
  `description` varchar(250) NOT NULL DEFAULT '',
  `diskfile` varchar(250) NOT NULL DEFAULT '',
  `filename` varchar(250) NOT NULL DEFAULT '',
  `folder` varchar(250) NOT NULL DEFAULT '',
  `filesize` int(11) NOT NULL DEFAULT 0,
  `file_type` varchar(250) NOT NULL DEFAULT '',
  `content` longblob DEFAULT NULL,
  `date_added` int(10) unsigned NOT NULL DEFAULT 1,
  `user_id` int(10) unsigned NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  KEY `idx_bug_file_bug_id` (`bug_id`),
  KEY `idx_diskfile` (`diskfile`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_bug_file_table: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_bug_file_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_bug_file_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_bug_history_table
DROP TABLE IF EXISTS `mantis_bug_history_table`;
CREATE TABLE IF NOT EXISTS `mantis_bug_history_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` int(10) unsigned NOT NULL DEFAULT 0,
  `bug_id` int(10) unsigned NOT NULL DEFAULT 0,
  `field_name` varchar(64) NOT NULL,
  `old_value` varchar(255) NOT NULL,
  `new_value` varchar(255) NOT NULL,
  `type` smallint(6) NOT NULL DEFAULT 0,
  `date_modified` int(10) unsigned NOT NULL DEFAULT 1,
  PRIMARY KEY (`id`),
  KEY `idx_bug_history_bug_id` (`bug_id`),
  KEY `idx_history_user_id` (`user_id`),
  KEY `idx_bug_history_date_modified` (`date_modified`)
) ENGINE=InnoDB AUTO_INCREMENT=320 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_bug_history_table: ~90 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_bug_history_table` DISABLE KEYS */;
INSERT INTO `mantis_bug_history_table` (`id`, `user_id`, `bug_id`, `field_name`, `old_value`, `new_value`, `type`, `date_modified`) VALUES
	(230, 1, 38, '', '', '', 1, 1646873954),
	(231, 1, 38, 'status', '10', '50', 0, 1646873954),
	(232, 1, 38, 'handler_id', '0', '1', 0, 1646873954),
	(233, 1, 39, '', '', '', 1, 1646876192),
	(234, 1, 39, 'status', '10', '50', 0, 1646876192),
	(235, 1, 39, 'handler_id', '0', '1', 0, 1646876192),
	(236, 1, 40, '', '', '', 1, 1647034921),
	(237, 1, 40, 'status', '10', '50', 0, 1647034921),
	(238, 1, 40, 'handler_id', '0', '1', 0, 1647034921),
	(239, 1, 41, '', '', '', 1, 1647464319),
	(240, 1, 41, 'status', '10', '50', 0, 1647464319),
	(241, 1, 41, 'handler_id', '0', '1', 0, 1647464319),
	(242, 1, 42, '', '', '', 1, 1647479387),
	(243, 1, 42, 'status', '10', '50', 0, 1647479387),
	(244, 1, 42, 'handler_id', '0', '1', 0, 1647479387),
	(245, 1, 43, '', '', '', 1, 1647479432),
	(246, 1, 43, 'status', '10', '50', 0, 1647479432),
	(247, 1, 43, 'handler_id', '0', '1', 0, 1647479432),
	(248, 1, 44, '', '', '', 1, 1647479531),
	(249, 1, 44, 'status', '10', '50', 0, 1647479531),
	(250, 1, 44, 'handler_id', '0', '1', 0, 1647479531),
	(251, 1, 45, '', '', '', 1, 1647479580),
	(252, 1, 45, 'status', '10', '50', 0, 1647479580),
	(253, 1, 45, 'handler_id', '0', '1', 0, 1647479580),
	(254, 1, 46, '', '', '', 1, 1647479830),
	(255, 1, 46, 'status', '10', '50', 0, 1647479830),
	(256, 1, 46, 'handler_id', '0', '1', 0, 1647479830),
	(257, 1, 47, '', '', '', 1, 1647480386),
	(258, 1, 47, 'status', '10', '50', 0, 1647480386),
	(259, 1, 47, 'handler_id', '0', '1', 0, 1647480386),
	(260, 1, 48, '', '', '', 1, 1647480759),
	(261, 1, 48, 'status', '10', '50', 0, 1647480759),
	(262, 1, 48, 'handler_id', '0', '1', 0, 1647480759),
	(263, 1, 49, '', '', '', 1, 1647484055),
	(264, 1, 49, 'status', '10', '50', 0, 1647484055),
	(265, 1, 49, 'handler_id', '0', '1', 0, 1647484055),
	(266, 1, 50, '', '', '', 1, 1649686874),
	(267, 1, 50, 'status', '10', '50', 0, 1649686874),
	(268, 1, 50, 'handler_id', '0', '1', 0, 1649686874),
	(269, 1, 50, '', 'release1', '', 25, 1649686874),
	(270, 1, 51, '', '', '', 1, 1649687408),
	(271, 1, 51, 'status', '10', '50', 0, 1649687408),
	(272, 1, 51, 'handler_id', '0', '1', 0, 1649687408),
	(273, 1, 51, '', 'release1', '', 25, 1649687408),
	(274, 1, 52, '', '', '', 1, 1649705383),
	(275, 1, 52, 'status', '10', '50', 0, 1649705383),
	(276, 1, 52, 'handler_id', '0', '1', 0, 1649705383),
	(277, 1, 52, '', 'release1', '', 25, 1649705383),
	(278, 1, 53, '', '', '', 1, 1649711333),
	(279, 1, 53, 'status', '10', '50', 0, 1649711333),
	(280, 1, 53, 'handler_id', '0', '1', 0, 1649711333),
	(281, 1, 54, '', '', '', 1, 1649712323),
	(282, 1, 54, 'status', '10', '50', 0, 1649712323),
	(283, 1, 54, 'handler_id', '0', '1', 0, 1649712323),
	(284, 1, 55, '', '', '', 1, 1650292684),
	(285, 1, 55, 'status', '10', '50', 0, 1650292684),
	(286, 1, 55, 'handler_id', '0', '1', 0, 1650292684),
	(287, 1, 56, '', '', '', 1, 1650292726),
	(288, 1, 56, 'status', '10', '50', 0, 1650292726),
	(289, 1, 56, 'handler_id', '0', '1', 0, 1650292726),
	(290, 1, 57, '', '', '', 1, 1650292807),
	(291, 1, 57, 'status', '10', '50', 0, 1650292807),
	(292, 1, 57, 'handler_id', '0', '1', 0, 1650292807),
	(293, 1, 57, '', 'release1', '', 25, 1650292807),
	(294, 1, 58, '', '', '', 1, 1650292856),
	(295, 1, 58, 'status', '10', '50', 0, 1650292856),
	(296, 1, 58, 'handler_id', '0', '1', 0, 1650292856),
	(297, 1, 58, '', 'release1', '', 25, 1650292856),
	(298, 1, 59, '', '', '', 1, 1650293042),
	(299, 1, 59, 'status', '10', '50', 0, 1650293042),
	(300, 1, 59, 'handler_id', '0', '1', 0, 1650293042),
	(301, 1, 59, '', 'release1', '', 25, 1650293042),
	(302, 1, 60, '', '', '', 1, 1650293323),
	(303, 1, 60, 'status', '10', '50', 0, 1650293323),
	(304, 1, 60, 'handler_id', '0', '1', 0, 1650293323),
	(305, 1, 61, '', '', '', 1, 1650317361),
	(306, 1, 61, 'status', '10', '50', 0, 1650317361),
	(307, 1, 61, 'handler_id', '0', '1', 0, 1650317361),
	(308, 1, 62, '', '', '', 1, 1650317580),
	(309, 1, 62, 'status', '10', '50', 0, 1650317580),
	(310, 1, 62, 'handler_id', '0', '1', 0, 1650317580),
	(311, 1, 62, '', 'release1', '', 25, 1650317580),
	(312, 1, 63, '', '', '', 1, 1650317604),
	(313, 1, 63, 'status', '10', '50', 0, 1650317604),
	(314, 1, 63, 'handler_id', '0', '1', 0, 1650317604),
	(315, 1, 63, '', 'release1', '', 25, 1650317604),
	(316, 1, 64, '', '', '', 1, 1650317689),
	(317, 1, 64, 'status', '10', '50', 0, 1650317689),
	(318, 1, 64, 'handler_id', '0', '1', 0, 1650317689),
	(319, 1, 64, '', 'release1', '', 25, 1650317689);
/*!40000 ALTER TABLE `mantis_bug_history_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_bug_monitor_table
DROP TABLE IF EXISTS `mantis_bug_monitor_table`;
CREATE TABLE IF NOT EXISTS `mantis_bug_monitor_table` (
  `user_id` int(10) unsigned NOT NULL DEFAULT 0,
  `bug_id` int(10) unsigned NOT NULL DEFAULT 0,
  PRIMARY KEY (`user_id`,`bug_id`),
  KEY `idx_bug_id` (`bug_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_bug_monitor_table: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_bug_monitor_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_bug_monitor_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_bug_relationship_table
DROP TABLE IF EXISTS `mantis_bug_relationship_table`;
CREATE TABLE IF NOT EXISTS `mantis_bug_relationship_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `source_bug_id` int(10) unsigned NOT NULL DEFAULT 0,
  `destination_bug_id` int(10) unsigned NOT NULL DEFAULT 0,
  `relationship_type` smallint(6) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  KEY `idx_relationship_source` (`source_bug_id`),
  KEY `idx_relationship_destination` (`destination_bug_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_bug_relationship_table: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_bug_relationship_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_bug_relationship_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_bug_revision_table
DROP TABLE IF EXISTS `mantis_bug_revision_table`;
CREATE TABLE IF NOT EXISTS `mantis_bug_revision_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `bug_id` int(10) unsigned NOT NULL,
  `bugnote_id` int(10) unsigned NOT NULL DEFAULT 0,
  `user_id` int(10) unsigned NOT NULL,
  `type` int(10) unsigned NOT NULL,
  `value` longtext NOT NULL,
  `timestamp` int(10) unsigned NOT NULL DEFAULT 1,
  PRIMARY KEY (`id`),
  KEY `idx_bug_rev_type` (`type`),
  KEY `idx_bug_rev_id_time` (`bug_id`,`timestamp`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_bug_revision_table: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_bug_revision_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_bug_revision_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_bug_table
DROP TABLE IF EXISTS `mantis_bug_table`;
CREATE TABLE IF NOT EXISTS `mantis_bug_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `project_id` int(10) unsigned NOT NULL DEFAULT 0,
  `reporter_id` int(10) unsigned NOT NULL DEFAULT 0,
  `handler_id` int(10) unsigned NOT NULL DEFAULT 0,
  `duplicate_id` int(10) unsigned NOT NULL DEFAULT 0,
  `priority` smallint(6) NOT NULL DEFAULT 30,
  `severity` smallint(6) NOT NULL DEFAULT 50,
  `reproducibility` smallint(6) NOT NULL DEFAULT 10,
  `status` smallint(6) NOT NULL DEFAULT 10,
  `resolution` smallint(6) NOT NULL DEFAULT 10,
  `projection` smallint(6) NOT NULL DEFAULT 10,
  `eta` smallint(6) NOT NULL DEFAULT 10,
  `bug_text_id` int(10) unsigned NOT NULL DEFAULT 0,
  `os` varchar(32) NOT NULL DEFAULT '',
  `os_build` varchar(32) NOT NULL DEFAULT '',
  `platform` varchar(32) NOT NULL DEFAULT '',
  `version` varchar(64) NOT NULL DEFAULT '',
  `fixed_in_version` varchar(64) NOT NULL DEFAULT '',
  `build` varchar(32) NOT NULL DEFAULT '',
  `profile_id` int(10) unsigned NOT NULL DEFAULT 0,
  `view_state` smallint(6) NOT NULL DEFAULT 10,
  `summary` varchar(128) NOT NULL DEFAULT '',
  `sponsorship_total` int(11) NOT NULL DEFAULT 0,
  `sticky` tinyint(4) NOT NULL DEFAULT 0,
  `target_version` varchar(64) NOT NULL DEFAULT '',
  `category_id` int(10) unsigned NOT NULL DEFAULT 1,
  `date_submitted` int(10) unsigned NOT NULL DEFAULT 1,
  `due_date` int(10) unsigned NOT NULL DEFAULT 1,
  `last_updated` int(10) unsigned NOT NULL DEFAULT 1,
  PRIMARY KEY (`id`),
  KEY `idx_bug_sponsorship_total` (`sponsorship_total`),
  KEY `idx_bug_fixed_in_version` (`fixed_in_version`),
  KEY `idx_bug_status` (`status`),
  KEY `idx_project` (`project_id`)
) ENGINE=InnoDB AUTO_INCREMENT=65 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_bug_table: ~27 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_bug_table` DISABLE KEYS */;
INSERT INTO `mantis_bug_table` (`id`, `project_id`, `reporter_id`, `handler_id`, `duplicate_id`, `priority`, `severity`, `reproducibility`, `status`, `resolution`, `projection`, `eta`, `bug_text_id`, `os`, `os_build`, `platform`, `version`, `fixed_in_version`, `build`, `profile_id`, `view_state`, `summary`, `sponsorship_total`, `sticky`, `target_version`, `category_id`, `date_submitted`, `due_date`, `last_updated`) VALUES
	(38, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 38, '', '', '', '', '', '', 0, 10, 'Bug nº 88395', 0, 0, '', 2, 1646873954, 1, 1646873954),
	(39, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 39, '', '', '', '', '', '', 0, 10, 'Bug nº 78461', 0, 0, '', 2, 1646876192, 1, 1646876192),
	(40, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 40, '', '', '', '', '', '', 0, 10, 'Bug nº 00328', 0, 0, '', 2, 1647034921, 1, 1647034921),
	(41, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 41, '', '', '', '', '', '', 0, 10, 'Bug nº 46186', 0, 0, '', 2, 1647464319, 1, 1647464319),
	(42, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 42, '', '', '', '', '', '', 0, 10, 'Bug nº 58921', 0, 0, '', 2, 1647479387, 1, 1647479387),
	(43, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 43, '', '', '', '', '', '', 0, 10, 'Bug nº 86655', 0, 0, '', 2, 1647479432, 1, 1647479432),
	(44, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 44, '', '', '', '', '', '', 0, 10, 'Bug nº 74823', 0, 0, '', 2, 1647479531, 1, 1647479531),
	(45, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 45, '', '', '', '', '', '', 0, 10, 'Bug nº 75475', 0, 0, '', 2, 1647479580, 1, 1647479580),
	(46, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 46, '', '', '', '', '', '', 0, 10, 'Bug nº 78426', 0, 0, '', 2, 1647479830, 1, 1647479830),
	(47, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 47, '', '', '', '', '', '', 0, 10, 'Bug nº 08981', 0, 0, '', 2, 1647480386, 1, 1647480386),
	(48, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 48, '', '', '', '', '', '', 0, 10, 'Bug nº 58240', 0, 0, '', 2, 1647480759, 1, 1647480759),
	(49, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 49, '', '', '', '', '', '', 0, 10, 'Bug nº 39263', 0, 0, '', 2, 1647484055, 1, 1647484055),
	(50, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 50, '', '', '', '', '', '', 0, 10, 'Falha ao carregar tela 224', 0, 0, '', 2, 1649686874, 1, 1649686874),
	(51, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 51, '', '', '', '', '', '', 0, 10, 'Falha ao carregar tela 003', 0, 0, '', 2, 1649687408, 1, 1649687408),
	(52, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 52, '', '', '', '', '', '', 0, 10, 'Falha ao carregar tela 141', 0, 0, '', 2, 1649705383, 1, 1649705383),
	(53, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 53, '', '', '', '', '', '', 0, 10, 'Bug nº 57237', 0, 0, '', 2, 1649711333, 1, 1649711333),
	(54, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 54, '', '', '', '', '', '', 0, 10, 'Bug nº 34943', 0, 0, '', 2, 1649712323, 1, 1649712323),
	(55, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 55, '', '', '', '', '', '', 0, 10, 'Bug nº 67671', 0, 0, '', 2, 1650292684, 1, 1650292684),
	(56, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 56, '', '', '', '', '', '', 0, 10, 'Bug nº 19186', 0, 0, '', 2, 1650292726, 1, 1650292726),
	(57, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 57, '', '', '', '', '', '', 0, 10, 'Falha ao carregar tela 229', 0, 0, '', 2, 1650292807, 1, 1650292807),
	(58, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 58, '', '', '', '', '', '', 0, 10, 'Falha ao carregar tela 543', 0, 0, '', 2, 1650292856, 1, 1650292856),
	(59, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 59, '', '', '', '', '', '', 0, 10, 'Falha ao carregar tela 390', 0, 0, '', 2, 1650293042, 1, 1650293042),
	(60, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 60, '', '', '', '', '', '', 0, 10, 'Bug nº 16650', 0, 0, '', 2, 1650293323, 1, 1650293323),
	(61, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 61, '', '', '', '', '', '', 0, 10, 'Bug nº 45543', 0, 0, '', 2, 1650317361, 1, 1650317361),
	(62, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 62, '', '', '', '', '', '', 0, 10, 'Falha ao carregar tela 913', 0, 0, '', 2, 1650317580, 1, 1650317580),
	(63, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 63, '', '', '', '', '', '', 0, 10, 'Falha ao carregar tela 766', 0, 0, '', 2, 1650317604, 1, 1650317604),
	(64, 13, 1, 1, 0, 40, 60, 10, 50, 10, 10, 10, 64, '', '', '', '', '', '', 0, 10, 'Falha ao carregar tela 881', 0, 0, '', 2, 1650317689, 1, 1650317689);
/*!40000 ALTER TABLE `mantis_bug_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_bug_tag_table
DROP TABLE IF EXISTS `mantis_bug_tag_table`;
CREATE TABLE IF NOT EXISTS `mantis_bug_tag_table` (
  `bug_id` int(10) unsigned NOT NULL DEFAULT 0,
  `tag_id` int(10) unsigned NOT NULL DEFAULT 0,
  `user_id` int(10) unsigned NOT NULL DEFAULT 0,
  `date_attached` int(10) unsigned NOT NULL DEFAULT 1,
  PRIMARY KEY (`bug_id`,`tag_id`),
  KEY `idx_bug_tag_tag_id` (`tag_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_bug_tag_table: ~9 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_bug_tag_table` DISABLE KEYS */;
INSERT INTO `mantis_bug_tag_table` (`bug_id`, `tag_id`, `user_id`, `date_attached`) VALUES
	(50, 5, 1, 1649686874),
	(51, 5, 1, 1649687408),
	(52, 5, 1, 1649705383),
	(57, 5, 1, 1650292807),
	(58, 5, 1, 1650292856),
	(59, 5, 1, 1650293042),
	(62, 5, 1, 1650317580),
	(63, 5, 1, 1650317604),
	(64, 5, 1, 1650317689);
/*!40000 ALTER TABLE `mantis_bug_tag_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_bug_text_table
DROP TABLE IF EXISTS `mantis_bug_text_table`;
CREATE TABLE IF NOT EXISTS `mantis_bug_text_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `description` longtext NOT NULL,
  `steps_to_reproduce` longtext NOT NULL,
  `additional_information` longtext NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=65 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_bug_text_table: ~27 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_bug_text_table` DISABLE KEYS */;
INSERT INTO `mantis_bug_text_table` (`id`, `description`, `steps_to_reproduce`, `additional_information`) VALUES
	(38, 'Teste Descrição', '', ''),
	(39, 'Teste Descrição', '', ''),
	(40, 'Teste Descrição', '', ''),
	(41, 'Teste Descrição', '', ''),
	(42, 'Teste Descrição', '', ''),
	(43, 'Teste Descrição', '', ''),
	(44, 'Teste Descrição', '', ''),
	(45, 'Teste Descrição', '', ''),
	(46, 'Teste Descrição', '', ''),
	(47, 'Teste Descrição', '', ''),
	(48, 'Teste Descrição', '', ''),
	(49, 'Teste Descrição', '', ''),
	(50, 'Teste Descrição', '', ''),
	(51, 'Teste Descrição', '', ''),
	(52, 'Teste Descrição', '', ''),
	(53, 'Teste Descrição', '', ''),
	(54, 'Teste Descrição', '', ''),
	(55, 'Teste Descrição', '', ''),
	(56, 'Teste Descrição', '', ''),
	(57, 'Teste Descrição', '', ''),
	(58, 'Teste Descrição', '', ''),
	(59, 'Teste Descrição', '', ''),
	(60, 'Teste Descrição', '', ''),
	(61, 'Teste Descrição', '', ''),
	(62, 'Teste Descrição', '', ''),
	(63, 'Teste Descrição', '', ''),
	(64, 'Teste Descrição', '', '');
/*!40000 ALTER TABLE `mantis_bug_text_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_category_table
DROP TABLE IF EXISTS `mantis_category_table`;
CREATE TABLE IF NOT EXISTS `mantis_category_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `project_id` int(10) unsigned NOT NULL DEFAULT 0,
  `user_id` int(10) unsigned NOT NULL DEFAULT 0,
  `name` varchar(128) NOT NULL DEFAULT '',
  `status` int(10) unsigned NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_category_project_name` (`project_id`,`name`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_category_table: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_category_table` DISABLE KEYS */;
INSERT INTO `mantis_category_table` (`id`, `project_id`, `user_id`, `name`, `status`) VALUES
	(1, 0, 0, 'General', 0),
	(2, 0, 0, 'TesteElvercio', 0);
/*!40000 ALTER TABLE `mantis_category_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_config_table
DROP TABLE IF EXISTS `mantis_config_table`;
CREATE TABLE IF NOT EXISTS `mantis_config_table` (
  `config_id` varchar(64) NOT NULL,
  `project_id` int(11) NOT NULL DEFAULT 0,
  `user_id` int(11) NOT NULL DEFAULT 0,
  `access_reqd` int(11) DEFAULT 0,
  `type` int(11) DEFAULT 90,
  `value` longtext NOT NULL,
  PRIMARY KEY (`config_id`,`project_id`,`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_config_table: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_config_table` DISABLE KEYS */;
INSERT INTO `mantis_config_table` (`config_id`, `project_id`, `user_id`, `access_reqd`, `type`, `value`) VALUES
	('database_version', 0, 0, 90, 1, '209');
/*!40000 ALTER TABLE `mantis_config_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_custom_field_project_table
DROP TABLE IF EXISTS `mantis_custom_field_project_table`;
CREATE TABLE IF NOT EXISTS `mantis_custom_field_project_table` (
  `field_id` int(11) NOT NULL DEFAULT 0,
  `project_id` int(10) unsigned NOT NULL DEFAULT 0,
  `sequence` smallint(6) NOT NULL DEFAULT 0,
  PRIMARY KEY (`field_id`,`project_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_custom_field_project_table: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_custom_field_project_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_custom_field_project_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_custom_field_string_table
DROP TABLE IF EXISTS `mantis_custom_field_string_table`;
CREATE TABLE IF NOT EXISTS `mantis_custom_field_string_table` (
  `field_id` int(11) NOT NULL DEFAULT 0,
  `bug_id` int(11) NOT NULL DEFAULT 0,
  `value` varchar(255) NOT NULL DEFAULT '',
  `text` longtext DEFAULT NULL,
  PRIMARY KEY (`field_id`,`bug_id`),
  KEY `idx_custom_field_bug` (`bug_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_custom_field_string_table: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_custom_field_string_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_custom_field_string_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_custom_field_table
DROP TABLE IF EXISTS `mantis_custom_field_table`;
CREATE TABLE IF NOT EXISTS `mantis_custom_field_table` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(64) NOT NULL DEFAULT '',
  `type` smallint(6) NOT NULL DEFAULT 0,
  `possible_values` text DEFAULT NULL,
  `default_value` varchar(255) NOT NULL DEFAULT '',
  `valid_regexp` varchar(255) NOT NULL DEFAULT '',
  `access_level_r` smallint(6) NOT NULL DEFAULT 0,
  `access_level_rw` smallint(6) NOT NULL DEFAULT 0,
  `length_min` int(11) NOT NULL DEFAULT 0,
  `length_max` int(11) NOT NULL DEFAULT 0,
  `require_report` tinyint(4) NOT NULL DEFAULT 0,
  `require_update` tinyint(4) NOT NULL DEFAULT 0,
  `display_report` tinyint(4) NOT NULL DEFAULT 0,
  `display_update` tinyint(4) NOT NULL DEFAULT 1,
  `require_resolved` tinyint(4) NOT NULL DEFAULT 0,
  `display_resolved` tinyint(4) NOT NULL DEFAULT 0,
  `display_closed` tinyint(4) NOT NULL DEFAULT 0,
  `require_closed` tinyint(4) NOT NULL DEFAULT 0,
  `filter_by` tinyint(4) NOT NULL DEFAULT 1,
  PRIMARY KEY (`id`),
  KEY `idx_custom_field_name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_custom_field_table: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_custom_field_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_custom_field_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_email_table
DROP TABLE IF EXISTS `mantis_email_table`;
CREATE TABLE IF NOT EXISTS `mantis_email_table` (
  `email_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `email` varchar(64) NOT NULL DEFAULT '',
  `subject` varchar(250) NOT NULL DEFAULT '',
  `metadata` longtext NOT NULL,
  `body` longtext NOT NULL,
  `submitted` int(10) unsigned NOT NULL DEFAULT 1,
  PRIMARY KEY (`email_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_email_table: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_email_table` DISABLE KEYS */;
INSERT INTO `mantis_email_table` (`email_id`, `email`, `subject`, `metadata`, `body`, `submitted`) VALUES
	(5, 'root@localhost', '[MantisBT] Password Reset', 'a:3:{s:7:"headers";a:0:{}s:7:"charset";s:5:"utf-8";s:8:"hostname";s:20:"host.docker.internal";}', 'Someone (presumably you) requested a password change through e-mail verification. If this was not you, ignore this message and nothing will happen.\n\nIf you requested this verification, visit the following URL to change your password: \n\nhttp://host.docker.internal:8989/verify.php?id=1&confirm_hash=7ZmmuzZ9pDfwOg8qULPp4iBrMdlqqFg3XxkLTQu2HjvlSJUV4StisaQ-rlySY82ufFkBpRFInS5gb9R0K1h2 \n\nUsername: administrator \nRemote IP address: 172.18.0.1 \n\nDo not reply to this message', 1647349379);
/*!40000 ALTER TABLE `mantis_email_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_filters_table
DROP TABLE IF EXISTS `mantis_filters_table`;
CREATE TABLE IF NOT EXISTS `mantis_filters_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL DEFAULT 0,
  `project_id` int(11) NOT NULL DEFAULT 0,
  `is_public` tinyint(4) DEFAULT NULL,
  `name` varchar(64) NOT NULL DEFAULT '',
  `filter_string` longtext NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_filters_table: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_filters_table` DISABLE KEYS */;
INSERT INTO `mantis_filters_table` (`id`, `user_id`, `project_id`, `is_public`, `name`, `filter_string`) VALUES
	(8, 1, 0, 0, 'filtroElvercio', 'v9#{"_version":"v9","_view_type":"simple","category_id":["TesteElvercio"],"severity":[0],"status":[0],"per_page":50,"highlight_changed":6,"reporter_id":[0],"handler_id":[0],"project_id":[-3],"sort":"last_updated","dir":"DESC","filter_by_date":false,"start_month":3,"start_day":1,"start_year":2022,"end_month":3,"end_day":9,"end_year":2022,"filter_by_last_updated_date":false,"last_updated_start_month":3,"last_updated_start_day":1,"last_updated_start_year":2022,"last_updated_end_month":3,"last_updated_end_day":9,"last_updated_end_year":2022,"search":"obst\\u00e1culo","hide_status":[90],"resolution":[0],"build":["0"],"version":["0"],"fixed_in_version":["0"],"target_version":["0"],"priority":[0],"monitor_user_id":[0],"view_state":0,"custom_fields":[],"sticky":true,"relationship_type":-1,"relationship_bug":0,"profile_id":[0],"platform":["0"],"os":["0"],"os_build":["0"],"tag_string":"","tag_select":0,"note_user_id":[0],"match_type":0}');
/*!40000 ALTER TABLE `mantis_filters_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_news_table
DROP TABLE IF EXISTS `mantis_news_table`;
CREATE TABLE IF NOT EXISTS `mantis_news_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `project_id` int(10) unsigned NOT NULL DEFAULT 0,
  `poster_id` int(10) unsigned NOT NULL DEFAULT 0,
  `view_state` smallint(6) NOT NULL DEFAULT 10,
  `announcement` tinyint(4) NOT NULL DEFAULT 0,
  `headline` varchar(64) NOT NULL DEFAULT '',
  `body` longtext NOT NULL,
  `last_modified` int(10) unsigned NOT NULL DEFAULT 1,
  `date_posted` int(10) unsigned NOT NULL DEFAULT 1,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_news_table: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_news_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_news_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_plugin_table
DROP TABLE IF EXISTS `mantis_plugin_table`;
CREATE TABLE IF NOT EXISTS `mantis_plugin_table` (
  `basename` varchar(40) NOT NULL,
  `enabled` tinyint(4) NOT NULL DEFAULT 0,
  `protected` tinyint(4) NOT NULL DEFAULT 0,
  `priority` int(10) unsigned NOT NULL DEFAULT 3,
  PRIMARY KEY (`basename`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_plugin_table: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_plugin_table` DISABLE KEYS */;
INSERT INTO `mantis_plugin_table` (`basename`, `enabled`, `protected`, `priority`) VALUES
	('MantisCoreFormatting', 1, 0, 3);
/*!40000 ALTER TABLE `mantis_plugin_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_project_file_table
DROP TABLE IF EXISTS `mantis_project_file_table`;
CREATE TABLE IF NOT EXISTS `mantis_project_file_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `project_id` int(10) unsigned NOT NULL DEFAULT 0,
  `title` varchar(250) NOT NULL DEFAULT '',
  `description` varchar(250) NOT NULL DEFAULT '',
  `diskfile` varchar(250) NOT NULL DEFAULT '',
  `filename` varchar(250) NOT NULL DEFAULT '',
  `folder` varchar(250) NOT NULL DEFAULT '',
  `filesize` int(11) NOT NULL DEFAULT 0,
  `file_type` varchar(250) NOT NULL DEFAULT '',
  `content` longblob DEFAULT NULL,
  `date_added` int(10) unsigned NOT NULL DEFAULT 1,
  `user_id` int(10) unsigned NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_project_file_table: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_project_file_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_project_file_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_project_hierarchy_table
DROP TABLE IF EXISTS `mantis_project_hierarchy_table`;
CREATE TABLE IF NOT EXISTS `mantis_project_hierarchy_table` (
  `child_id` int(10) unsigned NOT NULL,
  `parent_id` int(10) unsigned NOT NULL,
  `inherit_parent` tinyint(4) NOT NULL DEFAULT 0,
  UNIQUE KEY `idx_project_hierarchy` (`child_id`,`parent_id`),
  KEY `idx_project_hierarchy_child_id` (`child_id`),
  KEY `idx_project_hierarchy_parent_id` (`parent_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_project_hierarchy_table: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_project_hierarchy_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_project_hierarchy_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_project_table
DROP TABLE IF EXISTS `mantis_project_table`;
CREATE TABLE IF NOT EXISTS `mantis_project_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(128) NOT NULL DEFAULT '',
  `status` smallint(6) NOT NULL DEFAULT 10,
  `enabled` tinyint(4) NOT NULL DEFAULT 1,
  `view_state` smallint(6) NOT NULL DEFAULT 10,
  `access_min` smallint(6) NOT NULL DEFAULT 10,
  `file_path` varchar(250) NOT NULL DEFAULT '',
  `description` longtext NOT NULL,
  `category_id` int(10) unsigned NOT NULL DEFAULT 1,
  `inherit_global` tinyint(4) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_project_name` (`name`),
  KEY `idx_project_view` (`view_state`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_project_table: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_project_table` DISABLE KEYS */;
INSERT INTO `mantis_project_table` (`id`, `name`, `status`, `enabled`, `view_state`, `access_min`, `file_path`, `description`, `category_id`, `inherit_global`) VALUES
	(13, 'Projeto ElvercioNeto', 10, 1, 10, 10, '', 'Projeto alterado', 1, 1);
/*!40000 ALTER TABLE `mantis_project_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_project_user_list_table
DROP TABLE IF EXISTS `mantis_project_user_list_table`;
CREATE TABLE IF NOT EXISTS `mantis_project_user_list_table` (
  `project_id` int(10) unsigned NOT NULL DEFAULT 0,
  `user_id` int(10) unsigned NOT NULL DEFAULT 0,
  `access_level` smallint(6) NOT NULL DEFAULT 10,
  PRIMARY KEY (`project_id`,`user_id`),
  KEY `idx_project_user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_project_user_list_table: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_project_user_list_table` DISABLE KEYS */;
INSERT INTO `mantis_project_user_list_table` (`project_id`, `user_id`, `access_level`) VALUES
	(4, 3, 25),
	(13, 11, 25);
/*!40000 ALTER TABLE `mantis_project_user_list_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_project_version_table
DROP TABLE IF EXISTS `mantis_project_version_table`;
CREATE TABLE IF NOT EXISTS `mantis_project_version_table` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `project_id` int(10) unsigned NOT NULL DEFAULT 0,
  `version` varchar(64) NOT NULL DEFAULT '',
  `description` longtext NOT NULL,
  `released` tinyint(4) NOT NULL DEFAULT 1,
  `obsolete` tinyint(4) NOT NULL DEFAULT 0,
  `date_order` int(10) unsigned NOT NULL DEFAULT 1,
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_project_version` (`project_id`,`version`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_project_version_table: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_project_version_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_project_version_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_sponsorship_table
DROP TABLE IF EXISTS `mantis_sponsorship_table`;
CREATE TABLE IF NOT EXISTS `mantis_sponsorship_table` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `bug_id` int(11) NOT NULL DEFAULT 0,
  `user_id` int(11) NOT NULL DEFAULT 0,
  `amount` int(11) NOT NULL DEFAULT 0,
  `logo` varchar(128) NOT NULL DEFAULT '',
  `url` varchar(128) NOT NULL DEFAULT '',
  `paid` tinyint(4) NOT NULL DEFAULT 0,
  `date_submitted` int(10) unsigned NOT NULL DEFAULT 1,
  `last_updated` int(10) unsigned NOT NULL DEFAULT 1,
  PRIMARY KEY (`id`),
  KEY `idx_sponsorship_bug_id` (`bug_id`),
  KEY `idx_sponsorship_user_id` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_sponsorship_table: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_sponsorship_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_sponsorship_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_tag_table
DROP TABLE IF EXISTS `mantis_tag_table`;
CREATE TABLE IF NOT EXISTS `mantis_tag_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` int(10) unsigned NOT NULL DEFAULT 0,
  `name` varchar(100) NOT NULL DEFAULT '',
  `description` longtext NOT NULL,
  `date_created` int(10) unsigned NOT NULL DEFAULT 1,
  `date_updated` int(10) unsigned NOT NULL DEFAULT 1,
  PRIMARY KEY (`id`,`name`),
  KEY `idx_tag_name` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_tag_table: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_tag_table` DISABLE KEYS */;
INSERT INTO `mantis_tag_table` (`id`, `user_id`, `name`, `description`, `date_created`, `date_updated`) VALUES
	(5, 1, 'release1', '', 1646837466, 1646837466);
/*!40000 ALTER TABLE `mantis_tag_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_tokens_table
DROP TABLE IF EXISTS `mantis_tokens_table`;
CREATE TABLE IF NOT EXISTS `mantis_tokens_table` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `owner` int(11) NOT NULL,
  `type` int(11) NOT NULL,
  `value` longtext NOT NULL,
  `timestamp` int(10) unsigned NOT NULL DEFAULT 1,
  `expiry` int(10) unsigned NOT NULL DEFAULT 1,
  PRIMARY KEY (`id`),
  KEY `idx_typeowner` (`type`,`owner`)
) ENGINE=InnoDB AUTO_INCREMENT=102 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_tokens_table: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_tokens_table` DISABLE KEYS */;
INSERT INTO `mantis_tokens_table` (`id`, `owner`, `type`, `value`, `timestamp`, `expiry`) VALUES
	(91, 1, 5, '{"filter":false,"sidebar":false}', 1649703815, 1681239815),
	(100, 1, 3, '64,63,62,61,60', 1650292684, 1650404092);
/*!40000 ALTER TABLE `mantis_tokens_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_user_pref_table
DROP TABLE IF EXISTS `mantis_user_pref_table`;
CREATE TABLE IF NOT EXISTS `mantis_user_pref_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` int(10) unsigned NOT NULL DEFAULT 0,
  `project_id` int(10) unsigned NOT NULL DEFAULT 0,
  `default_profile` int(10) unsigned NOT NULL DEFAULT 0,
  `default_project` int(10) unsigned NOT NULL DEFAULT 0,
  `refresh_delay` int(11) NOT NULL DEFAULT 0,
  `redirect_delay` int(11) NOT NULL DEFAULT 0,
  `bugnote_order` varchar(4) NOT NULL DEFAULT 'ASC',
  `email_on_new` tinyint(4) NOT NULL DEFAULT 0,
  `email_on_assigned` tinyint(4) NOT NULL DEFAULT 0,
  `email_on_feedback` tinyint(4) NOT NULL DEFAULT 0,
  `email_on_resolved` tinyint(4) NOT NULL DEFAULT 0,
  `email_on_closed` tinyint(4) NOT NULL DEFAULT 0,
  `email_on_reopened` tinyint(4) NOT NULL DEFAULT 0,
  `email_on_bugnote` tinyint(4) NOT NULL DEFAULT 0,
  `email_on_status` tinyint(4) NOT NULL DEFAULT 0,
  `email_on_priority` tinyint(4) NOT NULL DEFAULT 0,
  `email_on_priority_min_severity` smallint(6) NOT NULL DEFAULT 10,
  `email_on_status_min_severity` smallint(6) NOT NULL DEFAULT 10,
  `email_on_bugnote_min_severity` smallint(6) NOT NULL DEFAULT 10,
  `email_on_reopened_min_severity` smallint(6) NOT NULL DEFAULT 10,
  `email_on_closed_min_severity` smallint(6) NOT NULL DEFAULT 10,
  `email_on_resolved_min_severity` smallint(6) NOT NULL DEFAULT 10,
  `email_on_feedback_min_severity` smallint(6) NOT NULL DEFAULT 10,
  `email_on_assigned_min_severity` smallint(6) NOT NULL DEFAULT 10,
  `email_on_new_min_severity` smallint(6) NOT NULL DEFAULT 10,
  `email_bugnote_limit` smallint(6) NOT NULL DEFAULT 0,
  `language` varchar(32) NOT NULL DEFAULT 'english',
  `timezone` varchar(32) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_user_pref_table: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_user_pref_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_user_pref_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_user_print_pref_table
DROP TABLE IF EXISTS `mantis_user_print_pref_table`;
CREATE TABLE IF NOT EXISTS `mantis_user_print_pref_table` (
  `user_id` int(10) unsigned NOT NULL DEFAULT 0,
  `print_pref` varchar(64) NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_user_print_pref_table: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_user_print_pref_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_user_print_pref_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_user_profile_table
DROP TABLE IF EXISTS `mantis_user_profile_table`;
CREATE TABLE IF NOT EXISTS `mantis_user_profile_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` int(10) unsigned NOT NULL DEFAULT 0,
  `platform` varchar(32) NOT NULL DEFAULT '',
  `os` varchar(32) NOT NULL DEFAULT '',
  `os_build` varchar(32) NOT NULL DEFAULT '',
  `description` longtext NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_user_profile_table: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_user_profile_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `mantis_user_profile_table` ENABLE KEYS */;

-- Copiando estrutura para tabela bugtracker.mantis_user_table
DROP TABLE IF EXISTS `mantis_user_table`;
CREATE TABLE IF NOT EXISTS `mantis_user_table` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(191) NOT NULL DEFAULT '',
  `realname` varchar(191) NOT NULL DEFAULT '',
  `email` varchar(191) NOT NULL DEFAULT '',
  `password` varchar(64) NOT NULL DEFAULT '',
  `enabled` tinyint(4) NOT NULL DEFAULT 1,
  `protected` tinyint(4) NOT NULL DEFAULT 0,
  `access_level` smallint(6) NOT NULL DEFAULT 10,
  `login_count` int(11) NOT NULL DEFAULT 0,
  `lost_password_request_count` smallint(6) NOT NULL DEFAULT 0,
  `failed_login_count` smallint(6) NOT NULL DEFAULT 0,
  `cookie_string` varchar(64) NOT NULL DEFAULT '',
  `last_visit` int(10) unsigned NOT NULL DEFAULT 1,
  `date_created` int(10) unsigned NOT NULL DEFAULT 1,
  PRIMARY KEY (`id`),
  UNIQUE KEY `idx_user_cookie_string` (`cookie_string`),
  UNIQUE KEY `idx_user_username` (`username`),
  KEY `idx_enable` (`enabled`),
  KEY `idx_access` (`access_level`),
  KEY `idx_email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela bugtracker.mantis_user_table: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `mantis_user_table` DISABLE KEYS */;
INSERT INTO `mantis_user_table` (`id`, `username`, `realname`, `email`, `password`, `enabled`, `protected`, `access_level`, `login_count`, `lost_password_request_count`, `failed_login_count`, `cookie_string`, `last_visit`, `date_created`) VALUES
	(1, 'administrator', '', 'root@localhost', '9094ad584141ac41890ca976a99cd4a8', 1, 0, 90, 295, 0, 0, 'omOE4WGNvUGzG6GMOj_Vlh7qqOhWUc5ikiKQbz1Fa4N-OkfWOt1f9-mRcv1Od76K', 1650375946, 1645727549),
	(11, 'tester', '', '', '2ae8d1b8b6cef8a5c705d31122830379', 1, 0, 25, 0, 0, 0, '6Hp3-AAihgJ3JnJeWEKcShLLIP-7tplNev6F0iSdg_PSI5DaBJrU09BdvIfBrcgJ', 1649274863, 1649274863);
/*!40000 ALTER TABLE `mantis_user_table` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
