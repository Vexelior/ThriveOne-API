-- Inserts for data migration
EXEC sp_addlinkedserver 
    @server = 'HOME_SERVER', 
    @srvproduct = '', 
    @provider = 'SQLNCLI', 
    @datasrc = '192.168.0.198,1433';

EXEC sp_addlinkedsrvlogin 
    @rmtsrvname = 'HOME_SERVER', 
    @useself = 'false', 
    @rmtuser = 'Alex', 
    @rmtpassword = 'Deadmau512#';

INSERT INTO ThriveOne.dbo.Todos (Id, Title, IsCompleted, Created, Completed, Description, Due)
SELECT NEWID(), Title, IsCompleted, Created, Completed, Description, Due
FROM [HOME_SERVER].Todo.dbo.Todos;



INSERT INTO ThriveOne.dbo.WorkTasks (Id, Title, Description, CompletedAt, DueDate, Priority, Status, Markdown, HTML)
SELECT NEWID(), Title, Description, CompletedAt, DueDate, Priority, Status, Markdown, HTML
FROM [HOME_SERVER].WorkTaskTracker.dbo.Tasks;



INSERT INTO ThriveOne.dbo.Debts (Id, Creditor, Amount, RemainingAmount, PreviousAmount, Notes, DateAdded, DateEdited, PercentageChange, Type, Image, ImageId, ImageSource, InterestRate, LastPayment, LastPaymentDate, MinimumPayment)
SELECT NEWID(), Creditor, Amount, RemainingAmount, PreviousAmount, Notes, DateAdded, DateEdited, PercentageChange, Type, Image, ImageId, ImageSource, InterestRate, LastPayment, LastPaymentDate, MinimumPayment
FROM [HOME_SERVER].debts.dbo.Debts;

