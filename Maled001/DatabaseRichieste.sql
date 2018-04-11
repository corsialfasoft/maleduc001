
CREATE DATABASE [RICHIESTE];
GO

SET QUOTED_IDENTIFIER OFF;
GO
USE [RICHIESTE];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RichiesteProdotti_Richieste]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RichiesteProdotti] DROP CONSTRAINT [FK_RichiesteProdotti_Richieste];
GO
IF OBJECT_ID(N'[dbo].[FK_RichiesteProdotti_Prodotti]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RichiesteProdotti] DROP CONSTRAINT [FK_RichiesteProdotti_Prodotti];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[RichiesteProdotti]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RichiesteProdotti];
GO
IF OBJECT_ID(N'[dbo].[RichiesteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RichiesteSet];
GO
IF OBJECT_ID(N'[dbo].[ProdottiSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProdottiSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RichiesteProdotti'
CREATE TABLE [dbo].[RichiesteProdotti] (
    [Richieste_Id] int  NOT NULL,
    [Prodotti_Id] int  NOT NULL,
    [quantita] int  NOT NULL
);
GO

-- Creating table 'RichiesteSet'
CREATE TABLE [dbo].[RichiesteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [data] datetime  NOT NULL
);
GO

-- Creating table 'ProdottiSet'
CREATE TABLE [dbo].[ProdottiSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [descrizione] nvarchar(max)  NOT NULL,
    [quantita] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Richieste_Id], [Prodotti_Id] in table 'RichiesteProdotti'
ALTER TABLE [dbo].[RichiesteProdotti]
ADD CONSTRAINT [PK_RichiesteProdotti]
    PRIMARY KEY CLUSTERED ([Richieste_Id], [Prodotti_Id] ASC);
GO

-- Creating primary key on [Id] in table 'RichiesteSet'
ALTER TABLE [dbo].[RichiesteSet]
ADD CONSTRAINT [PK_RichiesteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProdottiSet'
ALTER TABLE [dbo].[ProdottiSet]
ADD CONSTRAINT [PK_ProdottiSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Richieste_Id] in table 'RichiesteProdotti'
ALTER TABLE [dbo].[RichiesteProdotti]
ADD CONSTRAINT [FK_RichiesteProdotti_Richieste]
    FOREIGN KEY ([Richieste_Id])
    REFERENCES [dbo].[RichiesteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Prodotti_Id] in table 'RichiesteProdotti'
ALTER TABLE [dbo].[RichiesteProdotti]
ADD CONSTRAINT [FK_RichiesteProdotti_Prodotti]
    FOREIGN KEY ([Prodotti_Id])
    REFERENCES [dbo].[ProdottiSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RichiesteProdotti_Prodotti'
CREATE INDEX [IX_FK_RichiesteProdotti_Prodotti]
ON [dbo].[RichiesteProdotti]
    ([Prodotti_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------