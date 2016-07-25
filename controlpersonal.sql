-- phpMyAdmin SQL Dump
-- version 4.4.14
-- http://www.phpmyadmin.net
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 25-07-2016 a las 06:59:58
-- Versión del servidor: 5.6.26
-- Versión de PHP: 5.6.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `controlpersonal`
--

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_actualizarEvento`(pid INT,pdescripcion text,ptrabajador INT,ptipo varchar(20))
BEGIN
	UPDATE eventos set descripcion = pdescripcion,trabajador = ptrabajador,tipo = ptipo
    WHERE id = pid;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_actualizarPermiso`(pid INT,pcantidadDias int,pfechaInicio date, pfechaFin date,pdescripcion text, ptrabajador int,ptipo varchar(15))
BEGIN
	UPDATE permisos set cantidadDias = pCantidadDias, fechaInicio = pfechaInicio,fechaFin = pfechaFin,descripcion = pdescripcion,trabajador = ptrabajador,tipo = ptipo
    WHERE id = pid;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertarAcceso`(IN ptipo char(1), ptrabajador int)
BEGIN
	INSERT INTO acceso(hora,tipo,trabajador) VALUES (NOW(),ptipo,ptrabajador);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertarEvento`(IN ptipo varchar(50),IN pdescripcion text,IN ptrabajador INT)
BEGIN
	INSERT INTO `eventos`(tipo,descripcion,trabajador) VALUES(ptipo,pdescripcion,ptrabajador);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertarPermiso`(pcantidadDias int,pfechaInicio date, pfechaFin date,pdescripcion text, ptrabajador int,ptipo varchar(15))
BEGIN
INSERT INTO `permisos`(`cantidadDias`, `fechaInicio`, `fechaFin`, `descripcion`, `trabajador`, `tipo`)
VALUES (pcantidadDias,pfechaInicio,pfechaFin,pdescripcion,ptrabajador,ptipo);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertarTrabajador`(IN pnombre varchar(50), IN papePaterno varchar(50), IN papeMaterno varchar(50), pseguro BIT(1),IN pasignacionFamiliar BIT(1),IN psueldo decimal(6,2),IN parea char(1))
BEGIN
	INSERT INTO `trabajador`(nombre,apePaterno,apeMaterno,seguro,asignacionFamiliar,sueldo,area) VALUES(pnombre,papePaterno,papeMaterno,pseguro,pasignacionFamiliar,psueldo,parea);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_leerEvento`(IN `pid` INT)
BEGIN
	SELECT p.`id`,`descripcion`, `trabajador`, p.`tipo`,
	t.nombre as nombreTrabajador, t.apePaterno as apellidoTrabajador
	FROM `eventos` as p
	JOIN `trabajador` as t	
	WHERE p.trabajador = t.id AND p.id=pid;
	
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_leerPermiso`(pid INT)
BEGIN
	SELECT p.`id`, `cantidadDias`, `fechaInicio`, `fechaFin`, `descripcion`, `trabajador`, p.`tipo`,
	t.nombre as nombreTrabajador, t.apePaterno as apellidoTrabajador
	FROM `permisos` as p
	JOIN `trabajador` as t	
	WHERE p.trabajador = t.id AND p.id=pid;
	
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_leerUsuario`(IN pid INT )
BEGIN
	SELECT `id`, `username`, `pswd`, `tipo`, `trabajador` FROM `usuario`  WHERE  `id` = pid;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_listarAccesos`()
BEGIN
    		SELECT a.`id`, a.`hora`, a.`tipo`, a.`trabajador`,t.nombre as nombreTrabajador,t.apePaterno as apellidoTrabajador
				FROM `acceso` a
				JOIN `trabajador` as t	
				WHERE a.trabajador = t.id ORDER BY a.hora DESC;
    END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_listarEventos`(IN tipofiltro varchar(50))
BEGIN
	SELECT  e.`id`, e.`tipo`, e.`descripcion`, e.`trabajador`,t.nombre as nombreTrabajador,t.apePaterno as apellidoTrabajador
	 FROM `eventos` as e
	 JOIN `trabajador` as t	
	 WHERE e.trabajador = t.id 
	 AND e.tipo like CONCAT('%',tipofiltro,'%');
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_listarPermisos`(IN tipofiltro varchar(50))
BEGIN
	SELECT p.id, p.cantidadDias, p.fechaInicio, p.fechaFin, p.descripcion, p.trabajador, p.tipo,t.nombre as nombreTrabajador,t.apePaterno as apellidoTrabajador
	FROM `permisos` as p
	JOIN `trabajador` as t
	
	WHERE p.trabajador = t.id 
  AND tipo like CONCAT('%',tipofiltro,'%');
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_listarTrabajadores`()
BEGIN
	SELECT `id`, `nombre`, `apePaterno`, `apeMaterno`, `seguro`, `asignacionFamiliar`, `sueldo`, `area` FROM `trabajador`;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_verificarUsuario`(IN pusername VARCHAR(50), IN ppassword VARCHAR(200), OUT respuesta BOOLEAN, OUT idusu INT)
BEGIN
	IF EXISTS(SELECT * FROM usuario WHERE username = pusername and pswd = ppassword) then
        select 1 into respuesta;
			  select id from usuario WHERE username = pusername and pswd = ppassword into idusu;
        
    ELSE
         select 0 into respuesta;
				 select 0 into idusu;
         
    END IF;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `acceso`
--

CREATE TABLE IF NOT EXISTS `acceso` (
  `id` int(11) NOT NULL,
  `hora` datetime NOT NULL,
  `tipo` char(1) COLLATE utf8_spanish2_ci NOT NULL,
  `trabajador` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `acceso`
--

INSERT INTO `acceso` (`id`, `hora`, `tipo`, `trabajador`) VALUES
(5, '2016-07-24 23:50:00', 'E', 1),
(6, '2016-07-24 23:50:57', 'E', 2),
(7, '2016-07-24 23:53:56', 'S', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `eventos`
--

CREATE TABLE IF NOT EXISTS `eventos` (
  `id` int(11) NOT NULL,
  `tipo` enum('congratulation','amonestacion','sancion') COLLATE utf8_spanish2_ci NOT NULL,
  `descripcion` text COLLATE utf8_spanish2_ci NOT NULL,
  `trabajador` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `eventos`
--

INSERT INTO `eventos` (`id`, `tipo`, `descripcion`, `trabajador`) VALUES
(1, 'congratulation', 'ABC', 1),
(2, 'amonestacion', 'Amonestación', 1),
(3, 'sancion', 'sanción', 1),
(4, 'amonestacion', 'GEGE', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `permisos`
--

CREATE TABLE IF NOT EXISTS `permisos` (
  `id` int(11) NOT NULL,
  `cantidadDias` int(11) NOT NULL,
  `fechaInicio` date NOT NULL,
  `fechaFin` date NOT NULL,
  `descripcion` text COLLATE utf8_spanish2_ci NOT NULL,
  `trabajador` int(11) NOT NULL,
  `tipo` enum('licencias','permisos','vacaciones') COLLATE utf8_spanish2_ci NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `permisos`
--

INSERT INTO `permisos` (`id`, `cantidadDias`, `fechaInicio`, `fechaFin`, `descripcion`, `trabajador`, `tipo`) VALUES
(1, 10, '2016-07-20', '2016-07-20', 'Cumpleaños', 1, 'permisos'),
(2, 15, '2016-07-01', '2016-07-15', 'vacaciones', 2, 'vacaciones'),
(4, 5, '2016-07-24', '2016-07-27', 'Licencia x cualquier cosa.', 1, 'licencias');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `trabajador`
--

CREATE TABLE IF NOT EXISTS `trabajador` (
  `id` int(11) NOT NULL,
  `nombre` varchar(50) COLLATE utf8_spanish2_ci NOT NULL,
  `apePaterno` varchar(50) COLLATE utf8_spanish2_ci NOT NULL,
  `apeMaterno` varchar(50) COLLATE utf8_spanish2_ci NOT NULL,
  `seguro` bit(1) NOT NULL DEFAULT b'0',
  `asignacionFamiliar` bit(1) NOT NULL DEFAULT b'0',
  `sueldo` decimal(6,2) NOT NULL,
  `area` char(1) COLLATE utf8_spanish2_ci NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `trabajador`
--

INSERT INTO `trabajador` (`id`, `nombre`, `apePaterno`, `apeMaterno`, `seguro`, `asignacionFamiliar`, `sueldo`, `area`) VALUES
(1, 'Juan', 'Campos', 'Aquino', b'1', b'1', '4000.00', 'C'),
(2, 'Ramon', 'Valdez', 'Asd', b'1', b'1', '2500.00', 'R');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE IF NOT EXISTS `usuario` (
  `id` int(11) NOT NULL,
  `username` varchar(50) COLLATE utf8_spanish2_ci NOT NULL,
  `pswd` varchar(200) COLLATE utf8_spanish2_ci NOT NULL,
  `tipo` char(1) COLLATE utf8_spanish2_ci NOT NULL,
  `trabajador` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`id`, `username`, `pswd`, `tipo`, `trabajador`) VALUES
(1, 'newoverflow', '123', 'A', 0),
(2, 'contable', '123', 'C', 0);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `acceso`
--
ALTER TABLE `acceso`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `eventos`
--
ALTER TABLE `eventos`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `permisos`
--
ALTER TABLE `permisos`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `trabajador`
--
ALTER TABLE `trabajador`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `acceso`
--
ALTER TABLE `acceso`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT de la tabla `eventos`
--
ALTER TABLE `eventos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT de la tabla `permisos`
--
ALTER TABLE `permisos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT de la tabla `trabajador`
--
ALTER TABLE `trabajador`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
