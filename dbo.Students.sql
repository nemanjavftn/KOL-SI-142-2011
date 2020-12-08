﻿CREATE TABLE [dbo].[Students] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100)  NOT NULL,
    [IndexNumber] NVARCHAR (20)      NOT NULL,
    [AverageMark] DECIMAL (16, 2) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

