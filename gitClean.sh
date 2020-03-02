git checkout --orphan temp_branch
git add -A
git commit -am "Cleaned History 27-02-2020"
git branch -D master
git branch -m master
git push -f origin master
