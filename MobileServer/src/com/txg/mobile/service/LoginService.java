package com.txg.mobile.service;

import java.sql.ResultSet;
import java.sql.SQLException;

import com.txg.mobile.utils.SqlHelper;

public class LoginService {
	
	public boolean login(String mobile, String password) {
		SqlHelper sh = new SqlHelper();
		String sql = "select * from player where mobile = ? and password = ?";
		String[] params = { mobile, password };
		ResultSet rs = sh.queryExecute(sql, params);
		try {
			if (rs.next()) {
				return true;
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}
		return false;
	}
	
	

}
