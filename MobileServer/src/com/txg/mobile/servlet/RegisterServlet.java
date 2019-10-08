package com.txg.mobile.servlet;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.alibaba.fastjson.JSONObject;
import com.txg.mobile.service.RegisterService;


public class RegisterServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
	private RegisterService rs = new RegisterService();
	
	
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doPost(request, response);
	}

	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		request.setCharacterEncoding("utf-8");
		response.setCharacterEncoding("utf-8");
		
		String data = request.getParameter("data");
		JSONObject dataObject = JSONObject.parseObject(data);
		String mobile = dataObject.getString("mobile");
		String username = dataObject.getString("username");
		String password = dataObject.getString("password");

		PrintWriter writer = response.getWriter();
		
		if(rs.checkMobile(mobile) == true) {
			if(rs.register(mobile, username, password) == true) {
				writer.write("Register Successfully.");
			}else {
				writer.write("Register Fail.");
			}
			
		}else {
			writer.write("User Registed");
		}
		
	}

}
