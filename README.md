# telegra.ph
 - vs2019
 - net5.0
## 如何使用

 1. **使用api`ApiList.CreateAccount`创建一个账号获取token后,保存好token,来使用其他api**
 2. **具体api功能可以参照官方[API](https://telegra.ph/api)文档**
 3. [更多示例](https://github.com/FirmianaMarsili/telegra.ph/blob/main/telegraphTest/Program.cs)
 
### 怎么获取自己telegram账号下token
 1. **打开[telegraphBot](https://telegram.me/telegraph)**
 2. **通过点击bot消息下的`Log in as ... `Inline来登录于电脑浏览器**
 3. **(以Chrome为例) 打开`F12`/`Network`/`XHR`找到check,在`Headers`里找到`cookie`,其中的`tph_token`字段就是你账号的token**

# 扩展使用
  
 - **添加了上传文件的接口**
 - **`NodeElement`只实现了`Image``Link``Text``Video`,调用`NodeElement.ToJson`即可以获取到参数用的content**
 - **友情联动[隔壁项目](https://github.com/FirmianaMarsili/picacomic-api),又可以干很多好玩的事情**
 
 
 
