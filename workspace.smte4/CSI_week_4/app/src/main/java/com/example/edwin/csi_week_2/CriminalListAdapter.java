package com.example.edwin.csi_week_2;

import java.util.List;

import android.annotation.SuppressLint;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

@SuppressLint("InflateParams")  // See: https://code.google.com/p/android-developer-preview/issues/detail?id=1203
public class CriminalListAdapter extends ArrayAdapter<Criminal> {

	private Context context;
	private List<Criminal> criminals;

	public CriminalListAdapter(Context context, List<Criminal> criminals) {
		super(context, R.layout.criminallistitem, criminals);
		
		this.context = context;
		this.criminals = criminals;
	}
	
	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		
		Criminal requestedCriminal = criminals.get(position);
	
		if (convertView == null) {
            LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            View criminalView = inflater.inflate(R.layout.criminalslistitem, null);
        }

        ImageView mugshot = (ImageView) findViewById(R.layout.ivMugshot);
        TextView name = (TextView) findViewById(R.layout.tvName);
        TextView bounty = (TextView) findViewById(R.layout.tvBounty);

        int totalBounty = 0;

        for (Criminal item : criminals) {
            int currentBounty;
            currentBounty = item.getBountyInDollars();
            totalBounty = totalBounty + currentBounty;
        }
		
		return view;
	}

}
