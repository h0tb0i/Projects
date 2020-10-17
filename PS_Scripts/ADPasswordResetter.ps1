Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName PresentationCore,PresentationFramework

$Date = Get-Date -Format "yyyyMMdd"
$path = "C:\Temp\$Date" + "-passwords.csv"

[System.Reflection.Assembly]::LoadWithPartialName("System.Windows.Forms")
$result = [System.Windows.Forms.MessageBox]::Show('Please select a csv/txt file containing a single row list of employee IDs' , "Info" , 4)

if ($result -eq 'Yes') {
  
  
   
  Function Get-FileName($InitialDirectory)
    {
        [System.Reflection.Assembly]::LoadWithPartialName("System.windows.forms") | Out-Null

      $OpenFileDialog = New-Object System.Windows.Forms.OpenFileDialog
      $OpenFileDialog.initialDirectory = $initialDirectory
      $OpenFileDialog.filter = "CSV (*.csv) | *.csv"
      $OpenFileDialog.ShowDialog() | Out-Null

      $OpenFileDialog.FileName
    }

    

    $Users = Get-FileName


    function Generate-Password() {
        function Get-RandomCharacters($length, $characters) { 
            $random = 1..$length | ForEach-Object { Get-Random -Maximum $characters.length } 
            $private:ofs="" 
            return [String]$characters[$random]
        }

        $password += Get-RandomCharacters -length 1 -characters 'ABCDEFGHKLMNOPRSTUVWXYZ'
        $password += Get-RandomCharacters -length 5 -characters 'abcdefghiklmnoprstuvwxyz'
        $password += Get-RandomCharacters -length 4 -characters '1234567890'
        $password   
    
    }

    Get-Content $Users | ForEach-Object{
        
        $employeeID = $_
        $employeeID = $employeeID.PadLeft(5,'0')

        $UserID = Get-ADUser  -Properties * -Filter { EmployeeID -like $employeeID}
            
        $newPassword = Generate-Password
        
        Set-ADAccountPassword -Identity $UserID -Reset -NewPassword (ConvertTo-SecureString -AsPlainText $newPassword -Force) 

        [pscustomobject]@{
        ID = $UserID.EmployeeID
        Name=$UserID.displayName
        Email=$UserID.mail
        Password=$newPassword
            }    
    } | select ID, Name, email, Password | Export-Csv $path -NoTypeInformation

} else {
    exit
}
