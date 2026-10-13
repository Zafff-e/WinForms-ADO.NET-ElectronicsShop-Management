$connString = 'Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\Users\ahmza\Desktop\Project\ElectronicsShop\ElectronicsShop\ElectronicsPurchaseDB.mdf;Integrated Security=True'
$conn = New-Object System.Data.SqlClient.SqlConnection($connString)
try {
    $conn.Open()
    $cmd = $conn.CreateCommand()
    $cmd.CommandText = "INSERT INTO [dbo].[PurchaseTransaction] ([PurchaseDate], [BuyerName], [SupplierName], [DeliveryCharge], [TaxAmount], [Discount], [GrandTotal], [IsPaid]) OUTPUT INSERTED.PurchaseID VALUES (GETDATE(), 'Ahmed Khan', 'ABC Electronics', 500.00, 800.00, 200.00, 105500.00, 0);"
    $id = $cmd.ExecuteScalar()
    Write-Host "Inserted Purchase ID: $id"
    $cmd.CommandText = "INSERT INTO [dbo].[PurchaseItems] ([PurchaseID], [ProductName], [Quantity], [UnitPrice], [WarrantyMonths]) VALUES ($id, 'Laptop ASUS VivoBook 15', 2, 45000.00, 24), ($id, 'SSD Samsung 512GB', 5, 3500.00, 36), ($id, 'Wireless Mouse Logitech', 10, 800.00, 12);"
    $cmd.ExecuteNonQuery()
    Write-Host "Inserted Items successfully"
} catch {
    Write-Error $_.Exception.Message
} finally {
    $conn.Close()
}
