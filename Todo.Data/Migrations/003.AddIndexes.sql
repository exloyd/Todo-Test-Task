CREATE INDEX IF NOT EXISTS IX_Tasks_CategoryId ON Tasks(CategoryId);
CREATE INDEX IF NOT EXISTS IX_Tasks_Status ON Tasks(Status);
CREATE INDEX IF NOT EXISTS IX_Tasks_Priority ON Tasks(Priority);
CREATE INDEX IF NOT EXISTS IX_Tasks_CreatedAt ON Tasks(CreatedAt);

CREATE INDEX IF NOT EXISTS IX_Tasks_Priority_Status_CreatedAt ON Tasks(Priority DESC, Status ASC, CreatedAt DESC);

CREATE INDEX IF NOT EXISTS IX_Tasks_Title ON Tasks(Title);

CREATE INDEX IF NOT EXISTS IX_Categories_Name ON Categories(Name);