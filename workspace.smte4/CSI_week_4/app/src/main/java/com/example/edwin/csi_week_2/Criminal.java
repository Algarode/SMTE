package com.example.edwin.csi_week_2;

import java.util.ArrayList;
import android.graphics.drawable.Drawable;
import android.location.Location;

public class Criminal {

	public String name;
	public String gender;
	public String description;
	public int age;
	
	public ArrayList<com.example.edwin.Crime> crimes;
	
	public Drawable mugshot;
	public Location lastKnownLocation;
	
	public int getBountyInDollars() {
		int bounty = 0;
		for(Crime crime : crimes) {
			bounty += crime.bountyInDollars;
		}
		
		return bounty;
	}
}
