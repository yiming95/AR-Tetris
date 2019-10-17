# PORT:122.51.41.188
### +15176825513
### Post

**Register:**

&emsp;&emsp;MobileServer/RegisterServlet

&emsp;&emsp;&emsp;&emsp;data={"mobile":"XXX", "username":"XXX","password":"XXX"}

&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;Success:

&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;Fail:

**Verify Token:**

&emsp;&emsp;MobileServer/VerifyServlet

&emsp;&emsp;&emsp;&emsp;data={"action":"verify","mobile":"XXX","token":"XXX"}

&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;Success:

&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;Fail:

&emsp;&emsp;&emsp;&emsp;data={"action":"modify","mobile":"XXX"}

&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;Success:

&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;Fail:

**Login:**

&emsp;&emsp;MobileServer/LoginServlet

&emsp;&emsp;&emsp;&emsp;data={"mobile":"XXX","password":"XXX"}

&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;Success: username

&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;Fail:

**Upload Result:**

&emsp;&emsp;MobileServer/UploadServlet

&emsp;&emsp;&emsp;&emsp;data={"mobile":"XXX","mark":"XXX"}

&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;Success:

&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;Fail:

**RequestMark(Global top 10):**

&emsp;&emsp;MobileServer/RequestMarkServlet

&emsp;&emsp;&emsp;&emsp;Success:

&emsp;&emsp;&emsp;&emsp;Fail:

### --------------------------------------------------------------------------------

HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri("http://10.13.140.6:8080/MobileServer/RequestMarkServlet"));
        webReq.Method = "POST";
        webReq.ContentType = "application/x-www-form-urlencoded;charset=gb2312";
        using (WebResponse res = webReq.GetResponse())
        {
            //在这里对接收到的页面内容进行处理
            Stream responseStream = res.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8"));
            string str = streamReader.ReadToEnd();
            streamReader.Close();
            responseStream.Close();
            //返回：服务器响应流 
            Debug.LogError(str);
        }
