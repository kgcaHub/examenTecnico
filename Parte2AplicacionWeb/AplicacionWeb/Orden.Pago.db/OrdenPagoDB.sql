USE [OrdenPago]
GO
/****** Object:  Schema [OP]    Script Date: 18 Oct. 2018 03:52:15 ******/
CREATE SCHEMA [OP]
GO
/****** Object:  Table [OP].[banco]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [OP].[banco](
	[id] [uniqueidentifier] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[direccion] [nvarchar](100) NOT NULL,
	[esta_activo] [bit] NOT NULL,
	[usuario_registro] [nvarchar](20) NOT NULL,
	[fecha_registro] [datetime] NOT NULL,
	[usuario_modificacion] [nvarchar](20) NULL,
	[fecha_modificacion] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [OP].[orden_pago]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [OP].[orden_pago](
	[id] [uniqueidentifier] NOT NULL,
	[banco] [uniqueidentifier] NOT NULL,
	[sucursal] [uniqueidentifier] NULL,
	[monto] [numeric](8, 2) NOT NULL,
	[moneda] [nvarchar](7) NOT NULL,
	[estado] [nvarchar](9) NOT NULL,
	[fecha_pago] [date] NULL,
	[esta_activo] [bit] NOT NULL,
	[usuario_registro] [nvarchar](20) NOT NULL,
	[fecha_registro] [datetime] NOT NULL,
	[usuario_modificacion] [nvarchar](20) NULL,
	[fecha_modificacion] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [OP].[sucursal]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [OP].[sucursal](
	[id] [uniqueidentifier] NOT NULL,
	[banco] [uniqueidentifier] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[direccion] [nvarchar](100) NOT NULL,
	[esta_activo] [bit] NOT NULL,
	[usuario_registro] [nvarchar](20) NOT NULL,
	[fecha_registro] [datetime] NOT NULL,
	[usuario_modificacion] [nvarchar](20) NULL,
	[fecha_modificacion] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [OP].[SP_banco_actualizar]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [OP].[SP_banco_actualizar]
(
	@id			UNIQUEIDENTIFIER,
	@nombre		NVARCHAR(50),
	@direccion	NVARCHAR(100),
	@usuario	NVARCHAR(20)
)
AS
UPDATE OP.banco
SET
	nombre				= @nombre
,	direccion			= @direccion
,	usuario_modificacion= @usuario
,	fecha_modificacion	= GETDATE()
WHERE
	id					= @id;
GO
/****** Object:  StoredProcedure [OP].[SP_banco_eliminar]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [OP].[SP_banco_eliminar]
(
	@id			UNIQUEIDENTIFIER,
	@usuario	NVARCHAR(20)
)
AS
UPDATE OP.banco
SET
	esta_activo			= 0
,	usuario_modificacion= @usuario
,	fecha_modificacion	= GETDATE()
WHERE
	id					= @id;
GO
/****** Object:  StoredProcedure [OP].[SP_banco_insertar]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [OP].[SP_banco_insertar]
(
	@id			UNIQUEIDENTIFIER,
	@nombre		NVARCHAR(50),
	@direccion	NVARCHAR(100),
	@usuario	NVARCHAR(20)
)
AS
INSERT INTO OP.banco(id, nombre, direccion, esta_activo, usuario_registro, fecha_registro)
VALUES (@id, @nombre, @direccion, 1, @usuario, GETDATE());
GO
/****** Object:  StoredProcedure [OP].[SP_banco_listar]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [OP].[SP_banco_listar]
AS
SELECT 
		B.id,
		B.nombre
FROM 
		OP.banco B 
WHERE 
		B.esta_activo = 1;
GO
/****** Object:  StoredProcedure [OP].[SP_banco_obtener]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [OP].[SP_banco_obtener]
(
	@id	NVARCHAR(50)
)
AS
SELECT 
		B.nombre,
		B.direccion,
		B.fecha_registro
FROM 
		OP.banco B 
WHERE 
		B.id = @id;
GO
/****** Object:  StoredProcedure [OP].[SP_banco_obtener_nombre]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [OP].[SP_banco_obtener_nombre]
(
	@nombre		NVARCHAR(50)
)
AS
SELECT 
		B.id
FROM 
		OP.banco B 
WHERE 
		B.nombre = @nombre
		AND B.esta_activo = 1;
GO
/****** Object:  StoredProcedure [OP].[SP_orden_pago_actualizar]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [OP].[SP_orden_pago_actualizar]
(
	@id					UNIQUEIDENTIFIER,
	@banco				UNIQUEIDENTIFIER,
	@sucursal			UNIQUEIDENTIFIER	= NULL,
	@monto				NUMERIC(8,2),
	@moneda				NVARCHAR(7),
	@estado				VARCHAR(9),
	@fecha_pago			DATE				= NULL,
	@usuario			NVARCHAR(20)
)
AS
UPDATE OP.orden_pago
SET
	banco				= @banco
,	sucursal			= @sucursal
,	monto				= @monto
,	moneda				= @moneda
,	estado				= @estado
,	fecha_pago			= @fecha_pago
,	usuario_modificacion= @usuario
,	fecha_modificacion	= GETDATE()
WHERE
	id					= @id;
GO
/****** Object:  StoredProcedure [OP].[SP_orden_pago_eliminar]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [OP].[SP_orden_pago_eliminar]
(
	@id			UNIQUEIDENTIFIER,
	@usuario	NVARCHAR(20)
)
AS
UPDATE OP.orden_pago
SET
	esta_activo			= 0
,	usuario_modificacion= @usuario
,	fecha_modificacion	= GETDATE()
WHERE
	id					= @id;


GO
/****** Object:  StoredProcedure [OP].[SP_orden_pago_eliminar_banco]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [OP].[SP_orden_pago_eliminar_banco]
(
	@banco		UNIQUEIDENTIFIER,
	@usuario	NVARCHAR(20)
)
AS
UPDATE OP.orden_pago
SET
	esta_activo			= 0
,	usuario_modificacion= @usuario
,	fecha_modificacion	= GETDATE()
WHERE
	banco				= @banco;


GO
/****** Object:  StoredProcedure [OP].[SP_orden_pago_eliminar_sucursal]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [OP].[SP_orden_pago_eliminar_sucursal]
(
	@sucursal	UNIQUEIDENTIFIER,
	@usuario	NVARCHAR(20)
)
AS
UPDATE OP.orden_pago
SET
	esta_activo			= 0
,	usuario_modificacion= @usuario
,	fecha_modificacion	= GETDATE()
WHERE
	sucursal			= @sucursal;


GO
/****** Object:  StoredProcedure [OP].[SP_orden_pago_filtrar]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [OP].[SP_orden_pago_filtrar]
(
@moneda NVARCHAR(7),
@nombre_sucursal NVARCHAR(50)
)
AS
SELECT 
		O.id,
		O.monto,
		O.moneda,
		O.estado,
		O.fecha_pago
FROM 
		OP.orden_pago O
		INNER JOIN OP.sucursal S
		ON O.sucursal = S.id 
WHERE 
		O.moneda = @moneda
		AND S.nombre = @nombre_sucursal
		AND O.esta_activo = 1;
GO
/****** Object:  StoredProcedure [OP].[SP_orden_pago_insertar]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [OP].[SP_orden_pago_insertar]
(
	@id					UNIQUEIDENTIFIER,
	@banco				UNIQUEIDENTIFIER,
	@sucursal			UNIQUEIDENTIFIER	= NULL,
	@monto				NUMERIC(8,2),
	@moneda				NVARCHAR(7),
	@estado				VARCHAR(9),
	@fecha_pago			DATE				= NULL,
	@usuario			NVARCHAR(20)
)
AS
INSERT INTO OP.orden_pago(id, banco, sucursal, monto, moneda, estado, fecha_pago, esta_activo, usuario_registro, fecha_registro)
VALUES (@id, @banco, @sucursal, @monto, @moneda, @estado, @fecha_pago, 1, @usuario, GETDATE());

GO
/****** Object:  StoredProcedure [OP].[SP_orden_pago_listar]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [OP].[SP_orden_pago_listar]
(
	@sucursal		UNIQUEIDENTIFIER
)
AS
SELECT 
		O.id,
		O.monto
FROM 
		OP.orden_pago O
WHERE 
		O.sucursal = @sucursal
		AND O.esta_activo = 1;
GO
/****** Object:  StoredProcedure [OP].[SP_orden_pago_obtener]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [OP].[SP_orden_pago_obtener]
(
	@id UNIQUEIDENTIFIER
)
AS
SELECT 
		O.monto,
		O.moneda,
		O.estado,
		O.fecha_pago
FROM 
		OP.orden_pago O
WHERE 
		O.id = @id;
GO
/****** Object:  StoredProcedure [OP].[SP_sucursal_actualizar]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [OP].[SP_sucursal_actualizar]
(
	@id			UNIQUEIDENTIFIER,
	@banco		UNIQUEIDENTIFIER,
	@nombre		NVARCHAR(50),
	@direccion	NVARCHAR(100),
	@usuario	NVARCHAR(20)
)
AS
UPDATE OP.sucursal
SET
	banco				= @banco
,	nombre				= @nombre
,	direccion			= @direccion
,	usuario_modificacion= @usuario
,	fecha_modificacion	= GETDATE()
WHERE
	id					= @id;
GO
/****** Object:  StoredProcedure [OP].[SP_sucursal_eliminar]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [OP].[SP_sucursal_eliminar]
(
	@id			UNIQUEIDENTIFIER,
	@usuario	NVARCHAR(20)
)
AS
UPDATE OP.sucursal
SET
	esta_activo			= 0
,	usuario_modificacion= @usuario
,	fecha_modificacion	= GETDATE()
WHERE
	id					= @id;

GO
/****** Object:  StoredProcedure [OP].[SP_sucursal_eliminar_banco]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [OP].[SP_sucursal_eliminar_banco]
(
	@banco		UNIQUEIDENTIFIER,
	@usuario	NVARCHAR(20)
)
AS
UPDATE OP.sucursal
SET
	esta_activo			= 0
,	usuario_modificacion= @usuario
,	fecha_modificacion	= GETDATE()
WHERE
	banco				= @banco;


GO
/****** Object:  StoredProcedure [OP].[SP_sucursal_filtrar]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [OP].[SP_sucursal_filtrar]
(
@nombre_banco NVARCHAR(50)
)
AS
SELECT 
		S.id
	,	S.nombre
	,	S.direccion
	,	S.fecha_registro
FROM 
		OP.sucursal S
		INNER JOIN OP.banco B
		ON S.banco = B.id 
WHERE 
		B.nombre = @nombre_banco
		AND S.esta_activo = 1;
GO
/****** Object:  StoredProcedure [OP].[SP_sucursal_insertar]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [OP].[SP_sucursal_insertar]
(
	@id			UNIQUEIDENTIFIER,
	@banco		UNIQUEIDENTIFIER,
	@nombre		NVARCHAR(50),
	@direccion	NVARCHAR(100),
	@usuario	NVARCHAR(20)
)
AS
INSERT INTO OP.sucursal(id, banco, nombre, direccion, esta_activo, usuario_registro, fecha_registro)
VALUES (@id, @banco, @nombre, @direccion, 1, @usuario, GETDATE());

GO
/****** Object:  StoredProcedure [OP].[SP_sucursal_listar]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [OP].[SP_sucursal_listar]
(
	@banco		UNIQUEIDENTIFIER
)
AS
SELECT 
		S.id,
		S.nombre
FROM 
		OP.sucursal S 
WHERE 
		S.esta_activo = 1
		AND S.banco = @banco;
GO
/****** Object:  StoredProcedure [OP].[SP_sucursal_obtener]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [OP].[SP_sucursal_obtener]
(
	@id	NVARCHAR(50)
)
AS
SELECT 
		S.nombre,
		S.direccion,
		S.fecha_registro
FROM 
		OP.sucursal S 
WHERE 
		S.id = @id;
GO
/****** Object:  StoredProcedure [OP].[SP_sucursal_obtener_nombre]    Script Date: 18 Oct. 2018 03:52:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [OP].[SP_sucursal_obtener_nombre]
(
	@nombre		NVARCHAR(50),
	@banco		UNIQUEIDENTIFIER
)
AS
SELECT 
		S.id
FROM 
		OP.sucursal S 
WHERE 
			S.nombre		= @nombre
		AND S.banco			= @banco
		AND s.esta_activo	= 1;
GO
