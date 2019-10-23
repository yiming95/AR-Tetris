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
		} finally {
			sh.close();
		}
		return false;
	}

	public Integer findRank(String mobile) {
		SqlHelper sh = new SqlHelper();
		String sql = "select * from(\n" + "select * ,@current_rank := @current_rank + 1 as rank\n"
				+ "From mark m, (select @current_rank := 0)q\n" + "order by mark desc) AS r\n" + "where mobile = ?";
		String[] params = { mobile };
		ResultSet rs = sh.queryExecute(sql, params);
		try {
			if (rs.next()) {
				return rs.getInt("rank");
			}
		} catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
		return null;
	}

	public boolean insertMark(String mobile, String mark, Double gps_x, Double gps_y) {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		SqlHelper sh = new SqlHelper();
		String sql = "insert into mark values(?,?,?,?,?)";
		Object[] params = { mobile, mark, sdf.format(new Date()), gps_x, gps_y };
		if (sh.updateExecute(sql, params) > 0) {
			sh.close();
			return true;
		} else {
			sh.close();
			return false;
		}
	}

	public boolean updateMark(String mobile, String mark, Double gps_x, Double gps_y) {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		SqlHelper sh = new SqlHelper();
		String sql = "update mark set mark = ?, lastUpdate = ?, gps_x = ?, gps_y = ? where mobile = ?";
		Object[] params = { mark, sdf.format(new Date()), gps_x, gps_y, mobile };
		if (sh.updateExecute(sql, params) > 0) {
			sh.close();
			return true;
		} else {
			sh.close();
			return false;
		}
	}

	public List<Player> getGlobalTopMark(int top) {
		List<Player> result = new ArrayList<Player>();

		SqlHelper sh = new SqlHelper();
		String sql = "select m.mobile, m.mark, p.username from mark m left join player p "
				+ "on m.mobile = p.mobile order by m.mark desc limit ?";
		Object[] params = { top };
		try {
			ResultSet rs = sh.queryExecute(sql, params);
			while (rs.next()) {
				Player p = new Player();
				p.setMobile(rs.getString("mobile"));
				p.setUsername(rs.getString("username"));
				p.setMark(rs.getInt("mark"));
				result.add(p);
			}
		} catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		} finally {
			sh.close();
		}
		return result;
	}

	public Integer findLocalRank(String mobile, Double gps_x, Double gps_y, Double range) {
		// TODO Auto-generated method stub
		SqlHelper sh = new SqlHelper();
		String sql = "select * from "
				+ "(select * ,@current_rank := @current_rank + 1 as rank "
				+ "from mark m, (select @current_rank := 0)q "
				+ "where m.gps_x between ?-? and ?+? and m.gps_y between ?-? and ?+?"
				+ "order by mark desc) AS r where mobile = ?";
		Object[] params = {gps_x, range, gps_x, range, gps_y, range, gps_y, range, mobile };
		ResultSet rs = sh.queryExecute(sql, params);
		try {
			if (rs.next()) {
				return rs.getInt("rank");
			}
		} catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		}
		return null;
	}

	public List<Player> getLocalTopMark(Integer top, Double gps_x, Double gps_y, Double range) {
		// TODO Auto-generated method stub
		List<Player> result = new ArrayList<Player>();

		SqlHelper sh = new SqlHelper();
		String sql = " select * from mark m left join player p on m.mobile = p.mobile "
				+ "where m.gps_x between ?-? and ?+? and m.gps_y between ?-? and ?+? order by mark desc limit ?";
		Object[] params = {gps_x, range, gps_x, range, gps_y, range, gps_y, range, top};
		try {
			ResultSet rs = sh.queryExecute(sql, params);
			while (rs.next()) {
				Player p = new Player();
				p.setMobile(rs.getString("mobile"));
				p.setUsername(rs.getString("username"));
				p.setMark(rs.getInt("mark"));
				result.add(p);
			}
		} catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		} finally {
			sh.close();
		}
		return result;
	}

	public List<Double> getLocalCoor(String mobile) {
		// TODO Auto-generated method stub
		SqlHelper sh = new SqlHelper();
		String sql = "select * from mark where mobile = ?";
		ArrayList<Double> list = new ArrayList<Double>();
		String[] params = { mobile };
		ResultSet rs = sh.queryExecute(sql, params);
		try {
			if (rs.next()) {
				list.add(rs.getDouble("gps_x"));
				list.add(rs.getDouble("gps_y"));
				return list;
			}
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} finally {
			sh.close();
		}
		return null;
	}
}
