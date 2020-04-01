write-host "dotnet publish"
dotnet publish -o .\Release -c Release
write-host "git push"
git add .
$comment = read-host "git comment"
git commit -m '$comment'
git push -u origin master