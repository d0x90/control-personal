-- phpMyAdmin SQL Dump
-- version 4.4.14
-- http://www.phpmyadmin.net
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 25-07-2016 a las 21:06:13
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

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_actualizarTrabajador`(IN `pid` INT, IN `pnombre` VARCHAR(50), IN `papePaterno` VARCHAR(50), IN `papeMaterno` VARCHAR(50), IN `pseguro` BIT(1), IN `pasignacion` BIT(1), IN `parea` CHAR(1), IN `psueldo` DECIMAL(6,2))
BEGIN
UPDATE `trabajador` SET `id`=pid,`nombre`=pnombre,`apePaterno`=papePaterno,`apeMaterno`=papeMaterno,`seguro`=pSeguro,`asignacionFamiliar`=pAsignacion,`sueldo`=pSueldo,`area`=parea, `sueldo` = psueldo WHERE id=pid;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_actualizarUsuario`(IN `pid` INT, IN `pusername` VARCHAR(50), IN `ppswd` VARCHAR(200), IN `ptipo` CHAR(1), IN `ptrabajador` INT)
BEGIN
		UPDATE usuario SET username = pusername, pswd = ppswd, tipo = ptipo, trabajador = ptrabajador WHERE id = pid;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_eliminarEvento`(pid  INT)
BEGIN
	update eventos set estado = 0 where id = pid;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_eliminarPermiso`(pid INT)
BEGIN
	update permisos set estado = 0 where id = pid;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_eliminarTrabajador`(pid INT)
BEGIN
	update trabajador set estado = 0 where id = pid;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_eliminarUsuario`(pid INT)
BEGIN
	update usuario set estado = 0 where id = pid;
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

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insertarUsuario`(pusername varchar(50), ppswd varchar(200), ptipo char(1),ptrabajador int)
BEGIN
		INSERT INTO `usuario`(`username`, `pswd`, `tipo`, `trabajador`) 
        VALUES (pusername,ppswd,ptipo,ptrabajador);
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

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_leerTrabajador`(pid INT)
BEGIN
SELECT `id`, `nombre`, `apePaterno`, `apeMaterno`, `seguro`, `asignacionFamiliar`, `sueldo`, `area`, `estado` FROM `trabajador` WHERE id = pid;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_leerUsuario`(IN `pid` INT)
BEGIN
	SELECT u.`id`, u.`username`,u.`pswd`, u.`tipo`, u.`trabajador`,t.nombre as nombreTrabajador, t.apePaterno as apellidoTrabajador
    FROM `usuario` u
    JOIN trabajador t
    WHERE u.trabajador = t.id
    AND  u.`id` = pid;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_listarAccesos`()
BEGIN
    		SELECT a.`id`, a.`hora`, a.`tipo`, a.`trabajador`,t.nombre as nombreTrabajador,t.apePaterno as apellidoTrabajador, concat(t.nombre,' ',t.apePaterno, ' ', t.apeMaterno) as nombreCompleto
				FROM `acceso` a
				JOIN `trabajador` as t	
				WHERE a.trabajador = t.id
				AND a.estado = 1
				ORDER BY a.hora DESC;
    END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_listarEventos`(IN `tipofiltro` VARCHAR(50))
BEGIN
	SELECT  e.`id`, e.`tipo`, e.`descripcion`, e.`trabajador`,t.nombre as nombreTrabajador,t.apePaterno as apellidoTrabajador,concat(t.nombre,' ',t.apePaterno,' ',t.apeMaterno) as nombreCompleto
	 FROM `eventos` as e
	 JOIN `trabajador` as t	
	 WHERE e.trabajador = t.id 
	 AND e.estado = 1
	 AND e.tipo like CONCAT('%',tipofiltro,'%');
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_listarPermisos`(IN `tipofiltro` VARCHAR(50))
BEGIN
	SELECT p.id, p.cantidadDias, p.fechaInicio, p.fechaFin, p.descripcion, p.trabajador, p.tipo,t.nombre as nombreTrabajador,t.apePaterno as apellidoTrabajador, concat(t.nombre,' ',t.apePaterno,' ',t.apeMaterno) as nombreCompleto
	FROM `permisos` as p
	JOIN `trabajador` as t
	
	WHERE p.trabajador = t.id 
	AND p.estado = 1
  AND tipo like CONCAT('%',tipofiltro,'%');
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_listarTrabajadores`()
BEGIN
	SELECT `id`, `nombre`, `apePaterno`, `apeMaterno`, `seguro`, `asignacionFamiliar`, `sueldo`, `area`,`estado`, (SELECT CASE WHEN seguro <> 0 THEN "Sí" ELSE "No" END) as mostrarSeguro, (SELECT CASE WHEN asignacionFamiliar <> 0 THEN "Sí" ELSE "No" END) as mostrarAsignacion
	  
    FROM `trabajador`
		WHERE estado = 1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_listarUsuarios`()
BEGIN
			
    		SELECT  u.`id`, u.`username`, u.`pswd`, u.`tipo`, u.`trabajador`, u.`estado` ,t.nombre as nombreTrabajador,t.apePaterno as apellidoTrabajador, concat(t.nombre,' ',t.apePaterno, ' ', t.apeMaterno) as nombreCompleto,(SELECT CASE WHEN tipo = 'A' THEN "Administrador " WHEN tipo = 'C' THEN 'Contador' WHEN 'E' THEN 'especialista' WHEN 'R' THEN 'RR.HH' END) as mostrarTipo
				FROM `usuario` u
				JOIN `trabajador` as t	
				WHERE u.trabajador = t.id
				AND u.estado = 1;
				
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_verificarUsuario`(IN `pusername` VARCHAR(50), IN `ppassword` VARCHAR(200), OUT `respuesta` BOOLEAN, OUT `idusu` INT)
BEGIN
	IF EXISTS(SELECT * FROM usuario WHERE username = pusername and pswd = ppassword and  estado = 1 ) then
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
  `trabajador` int(11) NOT NULL,
  `estado` bit(1) NOT NULL DEFAULT b'1'
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `acceso`
--

INSERT INTO `acceso` (`id`, `hora`, `tipo`, `trabajador`, `estado`) VALUES
(5, '2016-07-24 23:50:00', 'E', 1, b'1'),
(6, '2016-07-24 23:50:57', 'E', 2, b'1'),
(7, '2016-07-24 23:53:56', 'S', 1, b'1'),
(8, '2016-07-25 08:41:31', 'S', 2, b'1'),
(9, '2016-07-25 13:03:17', 'E', 1, b'1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `eventos`
--

CREATE TABLE IF NOT EXISTS `eventos` (
  `id` int(11) NOT NULL,
  `tipo` enum('congratulation','amonestacion','sancion') COLLATE utf8_spanish2_ci NOT NULL,
  `descripcion` text COLLATE utf8_spanish2_ci NOT NULL,
  `trabajador` int(11) NOT NULL,
  `estado` bit(1) NOT NULL DEFAULT b'1'
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `eventos`
--

INSERT INTO `eventos` (`id`, `tipo`, `descripcion`, `trabajador`, `estado`) VALUES
(1, 'congratulation', 'ABC', 1, b'1'),
(2, 'amonestacion', 'Amonestación', 1, b'0'),
(3, 'sancion', 'sanción', 1, b'1'),
(4, 'amonestacion', 'GEGEsss', 1, b'0'),
(5, 'amonestacion', 'Amonestacion equisde', 1, b'1');

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
  `tipo` enum('licencias','permisos','vacaciones') COLLATE utf8_spanish2_ci NOT NULL,
  `estado` bit(1) NOT NULL DEFAULT b'1'
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `permisos`
--

INSERT INTO `permisos` (`id`, `cantidadDias`, `fechaInicio`, `fechaFin`, `descripcion`, `trabajador`, `tipo`, `estado`) VALUES
(1, 10, '2016-07-20', '2016-07-20', 'Cumpleaños', 1, 'permisos', b'1'),
(2, 15, '2016-07-01', '2016-07-15', 'vacaciones', 2, 'vacaciones', b'1'),
(4, 5, '2016-07-24', '2016-07-27', 'Licencia x cualquier cosa.', 1, 'licencias', b'1'),
(5, 1, '2016-07-25', '2016-07-25', 'Licencia', 2, 'licencias', b'0'),
(6, 1, '2016-07-25', '2016-07-25', '', 1, 'licencias', b'1');

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
  `area` char(1) COLLATE utf8_spanish2_ci NOT NULL,
  `estado` bit(1) NOT NULL DEFAULT b'1'
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `trabajador`
--

INSERT INTO `trabajador` (`id`, `nombre`, `apePaterno`, `apeMaterno`, `seguro`, `asignacionFamiliar`, `sueldo`, `area`, `estado`) VALUES
(1, 'Juan', 'Campos', 'Aquino', b'1', b'1', '3000.00', 'E', b'1'),
(2, 'Luis', 'Juarez', 'Ballena', b'1', b'0', '2500.00', 'R', b'1'),
(3, 'Cesar', 'Cordova', 'Rengifo', b'0', b'0', '5000.00', 'C', b'0'),
(4, 'Cesar', 'Cordova', 'Rengifo', b'1', b'1', '3000.00', 'C', b'1'),
(5, 'Diego', 'Campos', 'Ruiz', b'1', b'1', '6000.00', 'E', b'1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE IF NOT EXISTS `usuario` (
  `id` int(11) NOT NULL,
  `username` varchar(50) COLLATE utf8_spanish2_ci NOT NULL,
  `pswd` varchar(200) COLLATE utf8_spanish2_ci NOT NULL,
  `tipo` char(1) COLLATE utf8_spanish2_ci NOT NULL,
  `trabajador` int(11) NOT NULL,
  `estado` bit(1) NOT NULL DEFAULT b'1'
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`id`, `username`, `pswd`, `tipo`, `trabajador`, `estado`) VALUES
(1, 'especialista', '123', 'E', 1, b'1'),
(2, 'rrhh', '123', 'R', 2, b'1'),
(4, 'contador', '123', 'C', 4, b'1'),
(5, 'administrador', '123', 'A', 5, b'1');

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT de la tabla `eventos`
--
ALTER TABLE `eventos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT de la tabla `permisos`
--
ALTER TABLE `permisos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT de la tabla `trabajador`
--
ALTER TABLE `trabajador`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
