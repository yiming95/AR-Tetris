package com.txg.mobile.service;

import java.sql.ResultSet;
import java.sql.SQLException;

import com.txg.mobile.utils.SqlHelper;

public class LoginService {
	
	public String login(String mobile, String password) {
		SqlHelper sh = new SqlHelper();
		String sql = "select * from player where mobile = ? and password = ? and available = 1";
		String[] params = { mobile, password };
		ResultSet rs = sh.queryExecute(sql, params);
		try {
			if (rs.next()) {
				return rs.getString("username");
			}
		} catch (SQLException e) {
			e.printStackTrace();
		} finally {
			sh.close();
		}
		return null;
	}
	public Integer getMark(String mobile) {
		SqlHelper sh = new SqlHelper();
		String sql = "select * from mark where mobile = ?";
		String[] params = {mobile};
		ResultSet rs = sh.queryExecute(sql, params);
		try {
			if (rs.next()) {
				return rs.getInt("mark");
			}
		} catch (SQLException e) {
			e.printStackTrace();
		} finally {
			sh.close();
		}
		return null;
	}
	
	

}
