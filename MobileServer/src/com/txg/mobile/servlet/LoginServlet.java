package com.txg.mobile.servlet;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.alibaba.fastjson.JSONObject;
import com.txg.mobile.service.LoginService;
import com.txg.mobile.service.RegisterService;

public class LoginServlet extends HttpServlet{
	
	private static final long serialVersionUID = 1L;
    private LoginService ls = new LoginService();
	
	@Override
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		doPost(request, response);
	}

	@Override
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		String data = request.getParameter("data");
		JSONObject dataObject = JSONObject.parseObject(data);
		String mobile = dataObject.getString("mobile");
		String password = dataObject.getString("password");
		
		PrintWriter pw = response.getWriter();
		
		if (ls.login(mobile,password)==true) {
			pw.write("Login successful.");
		}else {
			pw.write("You need to register first.");
		}
	}
	

}
