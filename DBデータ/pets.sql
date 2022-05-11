SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[pets](
	[id]					[int] NOT NULL, 
	[userid]				[int] NOT NULL, 
	[kindsid]				[int] NOT NULL, 
	[pets_name]				[varchar](255) NOT NULL,
	[pets_age]				[int] NOT NULL,
	[pets_weight]			[float] NOT NULL,
	[pets_gender]			[bit] NOT NULL,
	[created_at]			datetime NOT NULL,
	[updated_at]			datetime NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO













