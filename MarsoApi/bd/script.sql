Base de datos debe llamarse api


CREATE TABLE [dbo].[GRUPO](
	[Id] [uniqueidentifier] NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
 CONSTRAINT [PK_GRUPO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[PRODUCTO](
	[Id] [uniqueidentifier] NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[Activo] [varchar](1) NOT NULL,
	[FECHA_CREACION] [datetime] NOT NULL,
	[USUARIO_CREACION] [varchar](50) NOT NULL,
	[Precio] [decimal](18, 8) NOT NULL,
	[Iva] [varchar](1) NOT NULL,
	[Descuento] [decimal](18, 8) NOT NULL,
	[FECHA_MODIFICACION] [datetime] NOT NULL,
	[USUARIO_MODIFICACION] [varchar](50) NOT NULL,
	[Grupo] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_GRUPO] FOREIGN KEY([Grupo])
REFERENCES [dbo].[GRUPO] ([Id])
GO

ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_GRUPO]
GO
