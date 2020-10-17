$name = "VPN"
$address = "ip_address"
$plainpassword = "passphrase"

$username = Read-Host 'What is your username?'

Add-VpnConnection -Name $name -ServerAddress $address -TunnelType L2tp -EncryptionLevel Required -AuthenticationMethod MSChapv2 -L2tpPsk "PSK" -Force:$true -RememberCredential:$true -SplitTunneling:$false 

Set-VpnConnectionUsernamePassword -connectionname $name -username $username -password $plainpassword -domain 'ad_domain'
