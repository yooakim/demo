

dotnet publish Basefarm.Demo.Web --configuration Release  --runtime win-x64
octo pack --id Basefarm.Demo.Web --basePath .\Basefarm.Demo.Web\bin\Release\netcoreapp2.0\publish --format=zip --outFolder=.\packaged

# Find out the name of the most recent file
$packageName = (get-childitem .\packaged\ -filter "*.zip" | Sort-Object LastWriteTime -Descending | Select-Object -First 1).Name

octo push --server=https://octopus.skl.se  --apiKey="$env:OCTOPUS_API_KEY" --ignoreSslErrors --package=.\packaged\$packageName

