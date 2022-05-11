SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[history](
	[id]					[int] NOT NULL, 
	[petid]					[int] NOT NULL, 
	[foodid]				[int] NOT NULL, 
	[change_food]			[int] NOT NULL,
	[memo]					[varchar](50) NOT NULL,
	[created_at]			datetime NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO













