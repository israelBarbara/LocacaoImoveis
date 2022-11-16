IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [IMOVEL] (
    [Id] int NOT NULL IDENTITY,
    [tipoImovel] int NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [VagasGaragem] int NOT NULL,
    [DataAnuncio] datetime2 NOT NULL,
    [NomProprietario] varchar(200) NOT NULL,
    [Descricao] varchar(200) NOT NULL,
    CONSTRAINT [PK_IMOVEL] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ENDERECO] (
    [Id] int NOT NULL IDENTITY,
    [Logradouro] varchar(200) NOT NULL,
    [Numero] varchar(50) NOT NULL,
    [Complemento] varchar(250) NOT NULL,
    [Cep] varchar(8) NOT NULL,
    [Bairro] varchar(100) NOT NULL,
    [Cidade] varchar(100) NOT NULL,
    [Estado] varchar(50) NOT NULL,
    [ImovelId] int NOT NULL,
    CONSTRAINT [PK_ENDERECO] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ENDERECO_IMOVEL_ImovelId] FOREIGN KEY ([ImovelId]) REFERENCES [IMOVEL] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [IMAGEM] (
    [Id] int NOT NULL IDENTITY,
    [CaminhoImagem] varchar(300) NOT NULL,
    [ImovelId] int NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    CONSTRAINT [PK_IMAGEM] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_IMAGEM_IMOVEL_ImovelId] FOREIGN KEY ([ImovelId]) REFERENCES [IMOVEL] ([Id]) ON DELETE NO ACTION
);
GO

CREATE UNIQUE INDEX [IX_ENDERECO_ImovelId] ON [ENDERECO] ([ImovelId]);
GO

CREATE INDEX [IX_IMAGEM_ImovelId] ON [IMAGEM] ([ImovelId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221115171513_Initial', N'5.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[IMAGEM]') AND [c].[name] = N'CaminhoImagem');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [IMAGEM] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [IMAGEM] ALTER COLUMN [CaminhoImagem] varchar(300) NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221116140306_imageSize', N'5.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [IMOVEL] ADD [Metros2] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221116172139_Metros2', N'5.0.0');
GO

COMMIT;
GO

