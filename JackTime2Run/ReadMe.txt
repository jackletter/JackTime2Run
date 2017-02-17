1.双击Manager.exe进入管理界面
2.第一次使用点击左侧按钮安装服务
3.服务安装好后点击开启服务
4.服务开启后点击刷新,即可看到当前配置的任务情况
5.若要启用、禁用、编辑、删除直接点击任务行对应的按钮即可
6.若要停止或卸载服务点击左侧对应按钮即可
7.若要添加任务点击左侧按钮即可
8.关于任务的配置属性说明:
	8.1 任务分三种(调用dll、调用c#编写的exe、编译并调用单个cs文件)
	8.2 共同配置,每个任务要有一个名称(设置好后就不可再改变)、Cron(定时任务表达式[http://jingyan.baidu.com/article/7f41ecec0d0724593d095c19.html])、日志类型(设置任务执行的成功与否的情况下是否记录日志)、是否可用
	8.3 dll任务配置:
		8.3.1 程序集搜索路径:要调用的dll或dll引用的程序集所在的路径,多路径使用";"分割,可以使用绝对路径或相对路径,比如我需要调用Dlls文件下的Demo2.dll那么我需要配置为"Dlls"。
		8.3.2 完整类名:要调用的类的名称,这里要加上dll的名称,比如我要调用Demo2.dll中的类Program,那么我需要配置"Demo2.Program, Demo2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"。
		8.3.2 方法名:要调用的类的方法,比如我要调用Demo2.dll中类Program的方法Show,那么我需要配置为"Show"
		8.3.4 参数:要给调用的方法传递的参数值(要调用的方法必须接受string[]类型的参数),填写参数则调用具有字符串数组参数的方法,不填写参数则调用空参数的方法。
	8.4 exe任务配置
		8.4.1 程序集搜索路径、日志记录、是否可用同dll的配置。
		8.4.2 完整类名:直接填写exe程序集的名称即可,比如我要调用Demo2.exe程序,就配置为"Demo2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
	8.5 单个cs文件的配置
		8.5.1 完整类名:直接写类的完整名称即可,比如我要调用Program.cs文件中的类Demo2.Program,就直接写"Demo2.Program"即可
		8.5.2 程序集搜索路径、日志记录、是否可用、方法名同dll的配置。
		8.5.3 cs文件路径:要调用的单个cs文件的路径,可以绝对地址或相对地址,比如我要调用DynamicCodes下的Program.cs文件则写"DynamicCodes\Program.cs"
		8.5.4 单个cs文件的书写方法参照"DynamicCodes\Program.cs"