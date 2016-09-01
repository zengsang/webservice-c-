# webservice-c-
a service by c#
这是我在线电子合同的后台，使用c#写的。主要是提供android端的后台方案，数据库的设计没有上传，但是代码结构很清晰，主要就是dboperation.cs这个类，它负责对数据库的操作。然后webservice.cs负责展示和调试。弄好之后通过iis进行发布，就可以在android端进行访问了。   <br  />
控制台接口展示：
-----------------------------------
![image]("http://b228.photo.store.qq.com/psb?/V13onOga2qcUC7/b6lgR7kQNtBQ8iBfXFPHRxRzfakDmZFUKVGXDRvmST8!/c/dOQAAAAAAAAA&bo=VQBxAFUAcQADACU!")
![image]("http://b143.photo.store.qq.com/psb?/V13onOga2qcUC7/4SQilTrC3cACQFJfKhjii4qbvLKHzqlJuD50e7PhOCI!/c/dI8AAAAAAAAA&bo=VQBxAFUAcQADACU!");
简要说明：
-----------------------------------
这个控制台是一个测试平台，在写完后台后进行测试，主要是服务器请求数据库然后进行相应的接口实现。  <br  />  在这里主要就是要注意IP地址，有些网络情况下可以直接使用ip，手机端也能正常使用， <br  />
但是有些ip地址却不行。特别是在WiFi下最容易出错。
发布后台说明：
-----------------------------------
这个后台用iis进行发布,在iis上建立网站,vs可以直接右击项目（推荐使用vs2010）选择发布到指定网站。  <br/>在iis中可以配置一些网站信息。（特别是ip）

