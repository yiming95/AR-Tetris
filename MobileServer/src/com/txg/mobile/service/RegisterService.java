package com.txg.mobile.service;

import java.sql.ResultSet;
import java.sql.SQLException;

import com.txg.mobile.utils.RandomString;
import com.txg.mobile.utils.SMSInvoke;
import com.txg.mobile.utils.SqlHelper;

public class RegisterService {

	public boolean checkMobile(String mobile) {
		SqlHelper sh = new SqlHelper();
		String sql = "select * from player where mobile = ?";
		String[] params = { mobile };
		ResultSet rs = sh.queryExecute(sql, params);
		try {
			if (rs.next()) {
				return false;
			}
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} finally {
			sh.close();
		}
		return true;
	}

	public boolean register(String mobile, String username, String password) {
		SqlHelper sh = new SqlHelper();
		String sql = "insert into player values(?,?,?,0,?)";
		String token = RandomString.generateRandom(6);
		String[] params = { mobile, username, password, token };
		if(sh.updateExecute(sql, params)>0) {
			SMSInvoke.sendVerified(token, mobile);
			sh.close();
			return true;
		}else {
			sh.close();
			return false;			
		}
	}
	
	public boolean changeToken(String mobile) {
		SqlHelper sh = new SqlHelper();
		String sql = "update player set token = ? where mobile = ?";
		String token = RandomString.generateRandom(6);
		String[] params = {token, mobile};
		if(sh.updateExecute(sql, params) > 0) {
			SMSInvoke.sendVerified(token, mobile);
			sh.close();
			return true;
		}else {
			sh.close();
			return false;
		}
		
	}
	
	public boolean verifyToken(String mobile, String token) {
		SqlHelper sh = new SqlHelper();
		String sql = "select * from player where mobile = ? and token = ?";
		String[] params = {mobile, token};
		ResultSet rs = sh.queryExecute(sql, params);
		try {
			if(rs.next()) {
				return changeAvailable(mobile);
			}else {
				return false;
			}
		} catch (Exception e) {
			// TODO: handle exception
		} finally{
			sh.close();
		}
		return false;
	}
	
	public boolean changeAvailable(String mobile) {
		SqlHelper sh = new SqlHelper();
		String sql = "update player set available = ? where mobile = ?";
		String[] params = {"1", mobile};
		if(sh.updateExecute(sql, params) > 0) {
			sh.close();
			return true;
		}else {
			sh.close();
			return false;
		}
	}
}
