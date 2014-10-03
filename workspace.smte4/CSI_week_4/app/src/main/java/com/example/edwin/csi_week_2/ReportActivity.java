package com.example.edwin.csi_week_2;

import android.content.Context;
import android.location.*;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CompoundButton;
import android.widget.Switch;

/**
 * Created by Edwin on 18-9-2014.
 */
public abstract class ReportActivity extends MainActivity implements LocationListener {

    Double lat, lon;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.report_activity);

        Button btnBack = (Button) findViewById(R.id.btnBack);
        btnBack.setOnClickListener(myhandler1);

        Switch switchSCA = (Switch) findViewById(R.id.switchSCA);
        switchSCA.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
                LocationManager locationManager = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
                locationManager.requestLocationUpdates(LocationManager.GPS_PROVIDER, 1000, 1, this);
            }
        });
    }

    View.OnClickListener myhandler1 = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            finish();
        }
    };

}