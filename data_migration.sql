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

-- Todos
INSERT INTO ThriveOne.dbo.Todos (Id, Title, IsCompleted, Created, Completed, Description, Due)
SELECT NEWID(), Title, IsCompleted, Created, Completed, Description, Due
FROM [HOME_SERVER].Todo.dbo.Todos;


-- Work Tasks
INSERT INTO ThriveOne.dbo.WorkTasks (Id, Title, Description, CompletedAt, DueDate, Priority, Status, Markdown, HTML)
SELECT NEWID(), Title, Description, CompletedAt, DueDate, Priority, Status, Markdown, HTML
FROM [HOME_SERVER].WorkTaskTracker.dbo.Tasks;


-- Debts
INSERT INTO ThriveOne.dbo.Debts (Id, Creditor, Amount, RemainingAmount, PreviousAmount, Notes, DateAdded, DateEdited, PercentageChange, Type, Image, ImageId, ImageSource, InterestRate, LastPayment, LastPaymentDate, MinimumPayment)
SELECT NEWID(), Creditor, Amount, RemainingAmount, PreviousAmount, Notes, DateAdded, DateEdited, PercentageChange, Type, Image, ImageId, ImageSource, InterestRate, LastPayment, LastPaymentDate, MinimumPayment
FROM [HOME_SERVER].debts.dbo.Debts;


-- Debt Images
INSERT INTO ThriveOne.dbo.DebtImages(Id, Name, Source, Uploaded)
SELECT NEWID(), Name, Source, Uploaded
FROM [HOME_SERVER].debts.dbo.Images;


-- Debt Charges
INSERT INTO ThriveOne.dbo.DebtInterestCharges(Id, DebtId, Amount, Date, Description)
SELECT NEWID(), DebtId, Amount, Date, Description
FROM [HOME_SERVER].debts.dbo.InterestCharges;


-- Debt Payments
INSERT INTO ThriveOne.dbo.DebtPayments(Id, DebtId, Amount, Date)
SELECT NEWID(), DebtId, Amount, Date
FROM [HOME_SERVER].debts.dbo.Payments;


-- Debt Previous Amounts
INSERT INTO ThriveOne.dbo.DebtPreviousAmounts(Id, Amount, PercentageChange, DebtId, Description, DateAdded)
SELECT NEWID(), Amount, PercentageChange, DebtId, Description, DateAdded
FROM [HOME_SERVER].debts.dbo.PreviousAmounts;


-- Debt Previous Percentages
INSERT INTO ThriveOne.dbo.DebtPreviousPercentages(Id, DebtId, [Percent], Date)
SELECT NEWID(), DebtId, Percentage, Date
FROM [HOME_SERVER].debts.dbo.PreviousPercentages;
