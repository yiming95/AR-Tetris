package com.txg.mobile.domain;

public class Player {

	private String mobile;
	private String username;
	private String password;
	private Boolean available;
	private Integer mark;
	
	public String getMobile() {
		return mobile;
	}
	public void setMobile(String mobile) {
		this.mobile = mobile;
	}
	public String getUsername() {
		return username;
	}
	public void setUsername(String username) {
		this.username = username;
	}
	public String getPassword() {
		return password;
	}
	public void setPassword(String password) {
		this.password = password;
	}
	public Boolean getAvailable() {
		return available;
	}
	public void setAvailable(Boolean available) {
		this.available = available;
	}
	public void setMark(Integer mark) {
		this.mark = mark;
	}
	public Integer getMark() {
		return mark;
	}
	
	@Override
	public String toString() {
		return "Player [mobile=" + mobile + ", username=" + username + ", password=" + password + ", available="
				+ available + "]";
	}
	
	
}
