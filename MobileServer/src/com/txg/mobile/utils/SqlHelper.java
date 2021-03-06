package com.txg.mobile.utils;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class SqlHelper {

	public Connection con;
	public PreparedStatement ps;
	public ResultSet rs;
	
	public String driver = "com.mysql.jdbc.Driver";
	public String url = "jdbc:mysql://127.0.0.1:3306/appserver?characterEncoding=utf-8&autoReconnect=true&serverTimezone=UTC";
	public String username = "root";
	public String password = "meiyoumima";
	
	public SqlHelper() {
		// TODO Auto-generated constructor stub
		try {
			Class.forName(driver);
			con = DriverManager.getConnection(url, username, password);
		} catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
	}
	
	public ResultSet queryExecute(String sql, String[] params) {
		try {
			ps = con.prepareStatement(sql);
			for(int i = 0;i< params.length; i++) {
				ps.setString(i+1, params[i]);
			}
			rs = ps.executeQuery();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return rs;
	}
	
	public ResultSet queryExecute(String sql, Object[] params) {
		try {
			ps = con.prepareStatement(sql);
			for(int i = 0; i< params.length; i++) {
				if (params[i].getClass().toString().split(" ")[1].equals("java.lang.Integer")) {
					ps.setInt(i+1, (int) params[i]);
				}else if(params[i].getClass().toString().split(" ")[1].equals("java.lang.String")) {
					ps.setString(i+1, (String) params[i]);
				}else if(params[i].getClass().toString().split(" ")[1].equals("java.lang.Double")) {
					ps.setDouble(i+1, (Double) params[i]);
				}
			}
			rs = ps.executeQuery();
		} catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
		return rs;
	}
	
	public int updateExecute(String sql, String[] params) {
		try {
			ps = con.prepareStatement(sql);
			for(int i = 0;i< params.length; i++) {
				ps.setString(i+1, params[i]);
			}
			return ps.executeUpdate();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return 0;
	}
	public int updateExecute(String sql, Object[] params) {
		try {
			ps = con.prepareStatement(sql);
			for(int i = 0; i< params.length; i++) {
				if (params[i].getClass().toString().split(" ")[1].equals("java.lang.Integer")) {
					ps.setInt(i+1, (int) params[i]);
				}else if(params[i].getClass().toString().split(" ")[1].equals("java.lang.String")) {
					ps.setString(i+1, (String) params[i]);
				}else if(params[i].getClass().toString().split(" ")[1].equals("java.lang.Double")) {
					ps.setDouble(i+1, (Double) params[i]);
				}
			}
			return ps.executeUpdate();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return 0;
	}
	
	public void close() {
		try {
			if(rs != null) rs.close();
			if(ps != null) ps.close();
			if(con != null) con.close();
		} catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
	}
	
}
