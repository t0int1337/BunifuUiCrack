$publicKeyHex = "002400000480000094000000060200000024000052534131000400000100010015a63d7b1e081b01dfd944ffa5d44a59339a92a607f9decd3eb33b009dab5a2b92afe61e538d16b2d1feb7808228c32c4e139c19aa4e41c5efad6e20a4d06f7abb18233aeef010506ddbc218feaf8d50aa64f27e8f50cfd655da46af9a596fef982c893f6a4c6327ad4fd30c798a3310551361524f0f699aafa2adda8aa77bf1"

# Convert hex string to byte array
$bytes = for ($i = 0; $i -lt $publicKeyHex.Length; $i += 2) {
    [Convert]::ToByte($publicKeyHex.Substring($i, 2), 16)
}

# Write bytes to file
[System.IO.File]::WriteAllBytes("$PSScriptRoot\BunifuPublicKey.snk", $bytes)
Write-Host "Key file created successfully at $PSScriptRoot\BunifuPublicKey.snk" 