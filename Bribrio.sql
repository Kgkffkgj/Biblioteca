-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           10.1.37-MariaDB - mariadb.org binary distribution
-- OS do Servidor:               Win32
-- HeidiSQL Versão:              9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Copiando estrutura do banco de dados para bibliotecapedro
CREATE DATABASE IF NOT EXISTS `bibliotecapedro` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `bibliotecapedro`;

-- Copiando estrutura para tabela bibliotecapedro.clientes
CREATE TABLE IF NOT EXISTS `clientes` (
  `idclientes` int(11) NOT NULL AUTO_INCREMENT,
  `nomeCliente` varchar(50) DEFAULT NULL,
  `rg` varchar(50) DEFAULT NULL,
  `telefone` varchar(30) DEFAULT NULL,
  `endereco` varchar(90) DEFAULT NULL,
  PRIMARY KEY (`idclientes`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela bibliotecapedro.clientes: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` (`idclientes`, `nomeCliente`, `rg`, `telefone`, `endereco`) VALUES
	(4, 'Luis', '17263637', '9927734', 'gonzaga'),
	(5, 'Pedro', '38888', '1111111', 'mALANDRO');
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;

-- Copiando estrutura para tabela bibliotecapedro.livros
CREATE TABLE IF NOT EXISTS `livros` (
  `idlivro` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(50) DEFAULT NULL,
  `editora` varchar(50) DEFAULT NULL,
  `autor` varchar(50) DEFAULT NULL,
  `anoPublic` varchar(4) DEFAULT NULL,
  PRIMARY KEY (`idlivro`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela bibliotecapedro.livros: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `livros` DISABLE KEYS */;
INSERT INTO `livros` (`idlivro`, `nome`, `editora`, `autor`, `anoPublic`) VALUES
	(5, 'Luana', 'Morgana', 'Morgana', '1887'),
	(6, 'Saintama', 'Disney', 'Manana', '1998');
/*!40000 ALTER TABLE `livros` ENABLE KEYS */;

-- Copiando estrutura para tabela bibliotecapedro.locacao
CREATE TABLE IF NOT EXISTS `locacao` (
  `idlocacao` int(11) NOT NULL AUTO_INCREMENT,
  `idlivro` int(11) DEFAULT NULL,
  `idcliente` int(11) DEFAULT NULL,
  PRIMARY KEY (`idlocacao`),
  KEY `fklivro` (`idlivro`),
  KEY `fkcliente` (`idcliente`),
  CONSTRAINT `fkcliente` FOREIGN KEY (`idcliente`) REFERENCES `clientes` (`idclientes`),
  CONSTRAINT `fklivro` FOREIGN KEY (`idlivro`) REFERENCES `livros` (`idlivro`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela bibliotecapedro.locacao: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `locacao` DISABLE KEYS */;
INSERT INTO `locacao` (`idlocacao`, `idlivro`, `idcliente`) VALUES
	(8, 5, 4),
	(9, 5, 5);
/*!40000 ALTER TABLE `locacao` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
