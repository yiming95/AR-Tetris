package com.txg.mobile.utils;

import java.util.List;

import com.alibaba.fastjson.JSONArray;
import com.alibaba.fastjson.JSONObject;
import com.txg.mobile.domain.Player;

public class ChangeToJSON {

	public static JSONArray playerToJSON(List<Player> list) {
		JSONArray array = new JSONArray();
		for(Player p : list) {
			JSONObject object = new JSONObject();
			if (p.getAvailable()!= null) {
				object.put("available", p.getAvailable());
			}
			if (p.getMark()!= null) {
				object.put("mark", p.getMark());
			}
			if (p.getMobile()!= null) {
				object.put("mobile", p.getMobile());
			}
			if (p.getUsername()!= null) {
				object.put("username", p.getUsername());
			}
			if (p.getPassword()!= null) {
				object.put("password", p.getPassword());
			}
			array.add(object);
		}
		return array;
	}
}
