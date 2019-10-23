package com.txg.mobile.servlet;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.alibaba.fastjson.JSONObject;
import com.txg.mobile.domain.Player;
import com.txg.mobile.service.MarkService;
import com.txg.mobile.utils.ChangeToJSON;

/**
 * Servlet implementation class RequestMarkServlet
 */
public class RequestMarkServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
    private MarkService ms = new MarkService();
	
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doPost(request, response);
	}

	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		System.out.println("RequestMarkServlet");
		request.setCharacterEncoding("utf-8");
		response.setCharacterEncoding("utf-8");
		String data = request.getParameter("data");
		JSONObject dataObject = JSONObject.parseObject(data);
		String mobile = dataObject.getString("mobile");
		Integer rank = ms.findRank(mobile);
		List<Player> list = ms.getGlobalTopMark(5);
		PrintWriter writer = response.getWriter();
		writer.write(rank+"@"+ChangeToJSON.playerToJSON(list).toString());
	}

}
