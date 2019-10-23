package com.txg.mobile.test;

import java.sql.ResultSet;
import java.sql.SQLException;

import org.junit.Test;

import com.txg.mobile.utils.SqlHelper;

public class JDBCTest {

	@Test
	public void jdbcTest() {
		SqlHelper sh = new SqlHelper();
		String sql = "insert into player values(?,?,?,0)";
		String[] params = {"18840824073", "DENG", "meiyoumima"};
		System.out.println(sh.updateExecute(sql, params));
	}
	
	@Test
	public void jdbcSearch() {
		SqlHelper sh = new SqlHelper();
		String sql = "select * from player";
		String[] params = {};
		ResultSet rs = sh.queryExecute(sql, params);
		try {
			while(rs.next()) {
				System.out.println(rs.getString("mobile"));
				System.out.println(rs.getString("username"));
				System.out.println(rs.getString("password"));
				System.out.println(rs.getBoolean("available"));
			}
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} finally {
			sh.close();
		}
	}
}
