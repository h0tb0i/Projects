Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName PresentationCore,PresentationFramework

$Date = Get-Date -Format "dd-MM-yy"
$path = "C:\Temp\$Date" + "-users.csv"
$OUpath = 'ou=Employee,ou=Users,dc=ad,dc=domain,dc=com,dc=au'
$i=1


$totalEmployees =  (Get-ADUser  -Properties * -Filter * -SearchBase $OUpath).count

$manager = ''

Function GetManager {
    $manager = (Get-ADUser -Properties manager -Filter 'Name -like "$_"').manager
}
       
Write-Output("Total Number of Users is  $totalEmployees")

Get-ADUser  -Properties * -Filter * -SearchBase $OUpath | ForEach-Object{             
        
        GetManager
            
        [pscustomobject]@{
        ID = $_.EmployeeID
        Name = $_.displayName
        Email = $_.mail
        JobTitle = $_.title
        Location = $_.extensionAttribute15
        Manager = $manager      
                    }

        $percent = ($i/$totalEmployees)*100
        $writepercent = [math]::Round($percent)

        Write-Progress -Activity "Retrieving Employees Data"  -Status "$percent% Complete" -PercentComplete $percent             
        $i++   

    } | select ID, Name, Email, JobTitle, Location | Export-Csv $path -NoTypeInformation
