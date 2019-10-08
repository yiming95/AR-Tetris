package com.txg.mobile.servlet;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.alibaba.fastjson.JSONObject;
import com.txg.mobile.service.RegisterService;


public class VerifyServlet extends HttpServlet {
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
		PrintWriter writer = response.getWriter();
		
		if(dataObject.getString("action").equals("verify")) {
			String mobile = dataObject.getString("mobile");
			String token = dataObject.getString("token");
			if (rs.verifyToken(mobile, token)) {
				writer.write("Verification Success");
			}else {
				writer.write("Verification Fail");
			}
		}else if (dataObject.getString("action").equals("modify")) {
			String mobile = dataObject.getString("mobile");
			if(rs.changeToken(mobile)) {
				writer.write("Modification Successful");
			}else {
				writer.write("Modification Fail");
			}
		}
	}

}
