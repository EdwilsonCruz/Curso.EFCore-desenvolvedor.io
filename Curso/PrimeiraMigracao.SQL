IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF SCHEMA_ID(N'Sistema') IS NULL EXEC(N'CREATE SCHEMA [Sistema];');

GO

CREATE TABLE [Sistema].[Cliente] (
    [Id] int NOT NULL IDENTITY,
    [Nome] VARCHAR(80) NOT NULL,
    [Telefone] CHAR(11) NOT NULL,
    [CEP] CHAR(8) NOT NULL,
    [Estado] nvarchar(60) NOT NULL,
    [Cidade] CHAR(2) NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Sistema].[Produto] (
    [Id] int NOT NULL IDENTITY,
    [CodigoBarras] VARCHAR(14) NOT NULL,
    [Descricao] VARCHAR(255) NULL,
    [Valor] nvarchar(max) NOT NULL,
    [TipoProduto] nvarchar(max) NOT NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Sistema].[Pedido] (
    [Id] int NOT NULL IDENTITY,
    [ClientId] int NOT NULL,
    [ClienteId] int NULL,
    [IniciadoEm] datetime2 NOT NULL DEFAULT (GETDATE()),
    [FinalizadoEm] datetime2 NOT NULL,
    [TipoFrete] int NOT NULL,
    [StatusPedido] nvarchar(max) NOT NULL,
    [Observacao] VARCHAR(512) NULL,
    CONSTRAINT [PK_Pedido] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pedido_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Sistema].[Cliente] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Sistema].[PedidoItem] (
    [Id] int NOT NULL IDENTITY,
    [IdPedido] int NOT NULL,
    [PedidoId] int NULL,
    [ProdutoId] int NOT NULL,
    [Quantidade] int NOT NULL DEFAULT 1,
    [Valor] decimal(18,2) NOT NULL,
    [Desconto] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_PedidoItem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PedidoItem_Pedido_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [Sistema].[Pedido] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PedidoItem_Produto_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Sistema].[Produto] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [idx_cliente_telefone] ON [Sistema].[Cliente] ([Telefone]);

GO

CREATE INDEX [IX_Pedido_ClienteId] ON [Sistema].[Pedido] ([ClienteId]);

GO

CREATE INDEX [IX_PedidoItem_PedidoId] ON [Sistema].[PedidoItem] ([PedidoId]);

GO

CREATE INDEX [IX_PedidoItem_ProdutoId] ON [Sistema].[PedidoItem] ([ProdutoId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210711211339_PrimeiraMigracao', N'3.1.5');

GO

