
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/29/2012 17:53:14
-- Generated from EDMX file: C:\GitHub\BUTE-Class-Administration-System\Database-Design\Database-Design\Class-Administration-Database.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [master];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'HallgatoSet'
CREATE TABLE [dbo].[HallgatoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Neptun] nvarchar(max)  NOT NULL,
    [Nev] nvarchar(max)  NOT NULL,
    [Felev] nvarchar(max)  NOT NULL,
    [Kurzus_Id] int  NULL,
    [Csoport_Id] int  NULL
);
GO

-- Creating table 'TeremSet'
CREATE TABLE [dbo].[TeremSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nev] nvarchar(max)  NOT NULL,
    [Gepek_szama] int  NOT NULL,
    [Ulohelyek_szama] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'GyakorlatvezetoSet'
CREATE TABLE [dbo].[GyakorlatvezetoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Neptun] nvarchar(max)  NOT NULL,
    [Nev] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CsoportSet'
CREATE TABLE [dbo].[CsoportSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Felev] nvarchar(max)  NOT NULL,
    [Sorszam] decimal(18,0)  NOT NULL,
    [Gyakorlatvezeto_Id] int  NOT NULL,
    [Kurzus_Id] int  NOT NULL,
    [Terem_Id] int  NOT NULL
);
GO

-- Creating table 'KurzusSet'
CREATE TABLE [dbo].[KurzusSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Felev] nvarchar(max)  NOT NULL,
    [Het_napja] decimal(18,0)  NOT NULL,
    [Het_paritasa] bit  NOT NULL,
    [Idosav_kezdete] time  NOT NULL
);
GO

-- Creating table 'TeremKurzus'
CREATE TABLE [dbo].[TeremKurzus] (
    [Terem_Id] int  NOT NULL,
    [Kurzus_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'HallgatoSet'
ALTER TABLE [dbo].[HallgatoSet]
ADD CONSTRAINT [PK_HallgatoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TeremSet'
ALTER TABLE [dbo].[TeremSet]
ADD CONSTRAINT [PK_TeremSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GyakorlatvezetoSet'
ALTER TABLE [dbo].[GyakorlatvezetoSet]
ADD CONSTRAINT [PK_GyakorlatvezetoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CsoportSet'
ALTER TABLE [dbo].[CsoportSet]
ADD CONSTRAINT [PK_CsoportSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KurzusSet'
ALTER TABLE [dbo].[KurzusSet]
ADD CONSTRAINT [PK_KurzusSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Terem_Id], [Kurzus_Id] in table 'TeremKurzus'
ALTER TABLE [dbo].[TeremKurzus]
ADD CONSTRAINT [PK_TeremKurzus]
    PRIMARY KEY NONCLUSTERED ([Terem_Id], [Kurzus_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Kurzus_Id] in table 'HallgatoSet'
ALTER TABLE [dbo].[HallgatoSet]
ADD CONSTRAINT [FK_HallgatoKurzus]
    FOREIGN KEY ([Kurzus_Id])
    REFERENCES [dbo].[KurzusSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HallgatoKurzus'
CREATE INDEX [IX_FK_HallgatoKurzus]
ON [dbo].[HallgatoSet]
    ([Kurzus_Id]);
GO

-- Creating foreign key on [Gyakorlatvezeto_Id] in table 'CsoportSet'
ALTER TABLE [dbo].[CsoportSet]
ADD CONSTRAINT [FK_CsoportGyakorlatvezeto]
    FOREIGN KEY ([Gyakorlatvezeto_Id])
    REFERENCES [dbo].[GyakorlatvezetoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CsoportGyakorlatvezeto'
CREATE INDEX [IX_FK_CsoportGyakorlatvezeto]
ON [dbo].[CsoportSet]
    ([Gyakorlatvezeto_Id]);
GO

-- Creating foreign key on [Kurzus_Id] in table 'CsoportSet'
ALTER TABLE [dbo].[CsoportSet]
ADD CONSTRAINT [FK_KurzusCsoport]
    FOREIGN KEY ([Kurzus_Id])
    REFERENCES [dbo].[KurzusSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KurzusCsoport'
CREATE INDEX [IX_FK_KurzusCsoport]
ON [dbo].[CsoportSet]
    ([Kurzus_Id]);
GO

-- Creating foreign key on [Terem_Id] in table 'TeremKurzus'
ALTER TABLE [dbo].[TeremKurzus]
ADD CONSTRAINT [FK_TeremKurzus_Terem]
    FOREIGN KEY ([Terem_Id])
    REFERENCES [dbo].[TeremSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Kurzus_Id] in table 'TeremKurzus'
ALTER TABLE [dbo].[TeremKurzus]
ADD CONSTRAINT [FK_TeremKurzus_Kurzus]
    FOREIGN KEY ([Kurzus_Id])
    REFERENCES [dbo].[KurzusSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TeremKurzus_Kurzus'
CREATE INDEX [IX_FK_TeremKurzus_Kurzus]
ON [dbo].[TeremKurzus]
    ([Kurzus_Id]);
GO

-- Creating foreign key on [Terem_Id] in table 'CsoportSet'
ALTER TABLE [dbo].[CsoportSet]
ADD CONSTRAINT [FK_CsoportTerem]
    FOREIGN KEY ([Terem_Id])
    REFERENCES [dbo].[TeremSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CsoportTerem'
CREATE INDEX [IX_FK_CsoportTerem]
ON [dbo].[CsoportSet]
    ([Terem_Id]);
GO

-- Creating foreign key on [Csoport_Id] in table 'HallgatoSet'
ALTER TABLE [dbo].[HallgatoSet]
ADD CONSTRAINT [FK_CsoportHallgato]
    FOREIGN KEY ([Csoport_Id])
    REFERENCES [dbo].[CsoportSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CsoportHallgato'
CREATE INDEX [IX_FK_CsoportHallgato]
ON [dbo].[HallgatoSet]
    ([Csoport_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------