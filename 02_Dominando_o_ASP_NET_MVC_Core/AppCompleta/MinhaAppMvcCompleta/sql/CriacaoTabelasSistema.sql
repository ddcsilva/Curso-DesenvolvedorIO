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

CREATE TABLE [TB_FORNECEDORES] (
    [FOR_ID] uniqueidentifier NOT NULL,
    [FOR_NOME] varchar(200) NOT NULL,
    [FOR_DOCUMENTO] varchar(14) NOT NULL,
    [FOR_TIPO] int NOT NULL,
    [FOR_ATIVO] bit NOT NULL,
    CONSTRAINT [PK_FORNECEDORES] PRIMARY KEY ([FOR_ID])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Tabela de Fornecedores';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_FORNECEDORES';
SET @description = N'Identificador Único do Fornecedor';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_FORNECEDORES', 'COLUMN', N'FOR_ID';
SET @description = N'Nome do Fornecedor';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_FORNECEDORES', 'COLUMN', N'FOR_NOME';
SET @description = N'Documento do Fornecedor';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_FORNECEDORES', 'COLUMN', N'FOR_DOCUMENTO';
SET @description = N'Tipo do Fornecedor';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_FORNECEDORES', 'COLUMN', N'FOR_TIPO';
SET @description = N'Indica se o Fornecedor está Ativo';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_FORNECEDORES', 'COLUMN', N'FOR_ATIVO';
GO

CREATE TABLE [TB_ENDERECOS] (
    [END_ID] uniqueidentifier NOT NULL,
    [END_LOGRADOURO] varchar(200) NOT NULL,
    [END_NUMERO] varchar(50) NOT NULL,
    [END_COMPLEMENTO] varchar(100) NOT NULL,
    [END_CEP] varchar(8) NOT NULL,
    [END_BAIRRO] varchar(100) NOT NULL,
    [END_CIDADE] varchar(100) NOT NULL,
    [END_ESTADO] varchar(50) NOT NULL,
    [FornecedorId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_ENDERECOS] PRIMARY KEY ([END_ID]),
    CONSTRAINT [FK_ENDERECO_FORNECEDOR] FOREIGN KEY ([FornecedorId]) REFERENCES [TB_FORNECEDORES] ([FOR_ID])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Tabela de Endereços';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_ENDERECOS';
SET @description = N'Identificador Único do Endereço';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_ENDERECOS', 'COLUMN', N'END_ID';
SET @description = N'Logradouro do Endereço';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_ENDERECOS', 'COLUMN', N'END_LOGRADOURO';
SET @description = N'Número do Endereço';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_ENDERECOS', 'COLUMN', N'END_NUMERO';
SET @description = N'Complemento do Endereço';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_ENDERECOS', 'COLUMN', N'END_COMPLEMENTO';
SET @description = N'CEP do Endereço';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_ENDERECOS', 'COLUMN', N'END_CEP';
SET @description = N'Bairro do Endereço';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_ENDERECOS', 'COLUMN', N'END_BAIRRO';
SET @description = N'Cidade do Endereço';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_ENDERECOS', 'COLUMN', N'END_CIDADE';
SET @description = N'Estado do Endereço';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_ENDERECOS', 'COLUMN', N'END_ESTADO';
GO

CREATE TABLE [TB_PRODUTOS] (
    [PRO_ID] uniqueidentifier NOT NULL,
    [PRO_NOME] varchar(200) NOT NULL,
    [PRO_DESCRICAO] varchar(1000) NOT NULL,
    [PRO_IMAGEM] varchar(100) NOT NULL,
    [PRO_VALOR] decimal(10,2) NOT NULL,
    [PRO_DATA_CADASTRO] datetime2 NOT NULL,
    [PRO_ATIVO] bit NOT NULL,
    [FornecedorId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_PRODUTOS] PRIMARY KEY ([PRO_ID]),
    CONSTRAINT [FK_PRODUTO_FORNECEDOR] FOREIGN KEY ([FornecedorId]) REFERENCES [TB_FORNECEDORES] ([FOR_ID])
);
DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Tabela de Produtos';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_PRODUTOS';
SET @description = N'Identificador Único do Produto';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_PRODUTOS', 'COLUMN', N'PRO_ID';
SET @description = N'Nome do Produto';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_PRODUTOS', 'COLUMN', N'PRO_NOME';
SET @description = N'Descrição do Produto';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_PRODUTOS', 'COLUMN', N'PRO_DESCRICAO';
SET @description = N'Nome do Arquivo da Imagem do Produto';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_PRODUTOS', 'COLUMN', N'PRO_IMAGEM';
SET @description = N'Valor do Produto';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_PRODUTOS', 'COLUMN', N'PRO_VALOR';
SET @description = N'Data de Cadastro do Produto';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_PRODUTOS', 'COLUMN', N'PRO_DATA_CADASTRO';
SET @description = N'Indica se o Produto está Ativo';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'TB_PRODUTOS', 'COLUMN', N'PRO_ATIVO';
GO

CREATE UNIQUE INDEX [IX_TB_ENDERECOS_FornecedorId] ON [TB_ENDERECOS] ([FornecedorId]);
GO

CREATE UNIQUE INDEX [IX_FORNECEDORES_DOCUMENTO] ON [TB_FORNECEDORES] ([FOR_DOCUMENTO]) WHERE [FOR_DOCUMENTO] IS NOT NULL;
GO

CREATE UNIQUE INDEX [IX_FORNECEDORES_NOME] ON [TB_FORNECEDORES] ([FOR_NOME]) WHERE [FOR_NOME] IS NOT NULL;
GO

CREATE UNIQUE INDEX [IX_PRODUTOS_NOME] ON [TB_PRODUTOS] ([PRO_NOME]) WHERE [PRO_NOME] IS NOT NULL;
GO

CREATE INDEX [IX_TB_PRODUTOS_FornecedorId] ON [TB_PRODUTOS] ([FornecedorId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240505235711_Initial', N'8.0.4');
GO

COMMIT;
GO

