package com.txg.mobile.service;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import com.txg.mobile.domain.Player;
import com.txg.mobile.utils.SqlHelper;

public class MarkService {

	public boolean findPlayer(String mobile) {
		SqlHelper sh = new SqlHelper();
		String sql = "select * from mark where mobile = ?";
		String[] params = { mobile };
		ResultSet rs = sh.queryExecute(sql, params);
		try {
			if (rs.next()) {
				return true;
			}
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return false;
	}
	
	public boolean insertMark(String mobile, String mark) {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		SqlHelper sh = new SqlHelper();
		String sql = "insert into mark values(?,?,?)";
		String[] params = { mobile, mark, sdf.format(new Date()) };
		if(sh.updateExecute(sql, params)>0) {
			return true;
		}else {
			return false;			
		}
	}
	public boolean updateMark(String mobile, String mark) {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		SqlHelper sh = new SqlHelper();
		String sql = "update mark set mark = ?, lastUpdate = ? where mobile = ?";
		String[] params = { mark, sdf.format(new Date()), mobile };
		if(sh.updateExecute(sql, params)>0) {
			return true;
		}else {
			return false;			
		}
	}
	
	public List<Player> getGlobalTopMark(int top){
		List<Player> result = new ArrayList<Player>();
		
		SqlHelper sh = new SqlHelper();
		String sql = "select m.mobile, m.mark, p.username from mark m left join player p "
				+ "on m.mobile = p.mobile order by m.mark limit ?";
		Object[] params = {top};
		try {
			ResultSet rs = sh.queryExecute(sql, params);
			while(rs.next()) {
				Player p = new Player();
				p.setMobile(rs.getString("mobile"));
				p.setUsername(rs.getString("username"));
				p.setMark(rs.getInt("mark"));
				result.add(p);
			}
		} catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
		return result;
	}
}
