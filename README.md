# 3dGameProject
Final Project of NCCUCS 10513dGame 

# Coding Style
採用[UpperCamelCase](https://zh.wikipedia.org/wiki/駝峰式大小寫)  
變數不要亂命名

# Something Else
Prefab、Scripts等等請分類放進對應資料夾  

#Tutorial
不會使用Git的話可以參考  
[30 天精通 Git 版本控管](https://github.com/doggy8088/Learn-Git-in-30-days)  
[連少維都能懂的git入門指南](https://backlogtool.com/git-guide/tw/)  
[git教學](https://www.gitbook.com/book/kingofamani/git-teach/details)  

#參考流程#
	
以下直接是寫執行命令，如果是用其它工具的人，UI上應該會有對應的功能。  
如果怕會把git搞爛，就參考以下的流程，Fork回去，再Pull Request上來，至少我可以審過(?)，確定OK的話可以跟我說，我在把權限開給你  

1. 點選 fork 將專案複製至自已的帳號底下，  
2. 將你 fork 過去的專案，也就是你自己的專案 clone 到你的本地端  
3. 在 clone 的專案下新建分支（branch），並切換到你的分支上，名稱可取為「trans」，命令為`git branch trans` + `git checkout trans`  
4. 執行 `git remote add upstream https://github.com/www10177/3dGameProject.git` 將本庫加為遠端庫  
5. 執行 `git remote update` 更新  
6. 執行 `git fetch upstream master` 拉取本庫更新到你的本地  
7. 執行 `git rebase upstream/master` 將更新內容整併到你的分支  

以上為初始化流程，如果 upstream 有更新請執行 5~7 即可，平時請在自己的分支上作業。  
最後發 pull-request 將更新內容加回至本專案，每次發之前請務必確認是否同步了最新版。  

#推薦Git Tool#
[SourceTree](https://www.sourcetreeapp.com)  

#其他#
* Commit內容不要亂寫，中文或英文都可以，就把你做的事情備註上去  
* 沒有必要做了點小更動就Commit，大概一小個段落一小個段落再Commit這樣  
*  如果Local跟Remote有動到同個檔案時會有Coflict的問題，到時候再來解吧，我也不一定會A_A  
* 建議是開始編輯前先檢查一下Remote有沒有Upadate  

 我也是第一次管Git project所以可能也會有問題XD有其他問題再說吧  
