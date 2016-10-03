# 文件上传
## 你可以简单的使用js中uploadFile来上传

----------
js中uploadFile(file, slice, php)

file 表示一个文件指针

slice 表示分片大小，默认为1M

php 表示后台处理文件，默认为"uploadFile.php"

----------
php中的uploadFile()

读取uploadFile上传的数据，并储存在对应的目录中

----------
config.json

path:   配置上传时的临时目录

time_limit: 配置合并文件时的超时时间
