$UserFieldType = Get-ADUser -Filter { [_fieldtype_] -like "[_OutdatedValue_]" }

foreach($UserFieldType in $UserFieldTypes)
{
    Write-Output $UserFieldType
    $postalCode = "0000"
    
    try{
     Set-ADUuser $UserFieldType -PostalCode $postalCode -whatif
     "$($MayfieldUser.name) - Was updated"
     } catch {
     write-warning("$($MayfieldUser.name) - Did not get updated")
     }
}
