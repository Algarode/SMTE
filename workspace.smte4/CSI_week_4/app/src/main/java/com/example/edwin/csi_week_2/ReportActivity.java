package com.example.edwin.csi_week_2;

import android.content.Context;
import android.location.*;
import android.os.Bundle;
import android.os.Vibrator;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.CompoundButton;
import android.widget.Switch;

/**
 * Created by Edwin on 18-9-2014.
 */
public abstract class ReportActivity extends MainActivity implements LocationListener {

    private Double lat, lon;
    private LocationManager locationManager;
    private LocationListener locationListener;
    private Vibrator vibrator;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.report_activity);

        locationManager = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
        vibrator = (Vibrator) getSystemService(Context.VIBRATOR_SERVICE);

        Button btnBack = (Button) findViewById(R.id.btnBack);
        btnBack.setOnClickListener(myhandler1);

        Switch switchSCA = (Switch) findViewById(R.id.switchSCA);
        switchSCA.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton compoundButton, boolean b) {
                if (b) {
                    locationListener = new LocationListener() {
                        @Override
                        public void onLocationChanged(Location location) {
                            lat = location.getLatitude();
                            lon = location.getLongitude();

                            Log.i("Message ", "Locatie: " + lat + ", " + lon);
                        }

                        @Override
                        public void onStatusChanged(String s, int i, Bundle bundle) {

                        }

                        @Override
                        public void onProviderEnabled(String s) {

                        }

                        @Override
                        public void onProviderDisabled(String s) {

                        }
                    };

                    locationManager.requestLocationUpdates(LocationManager.GPS_PROVIDER, 1000, 1, locationListener);
                    String locationProvider = LocationManager.NETWORK_PROVIDER;
                    Location lastKnownLocation = locationManager.getLastKnownLocation(locationProvider);

                    float[] results = new float[5];
                    Location.distanceBetween(lat, lon, lastKnownLocation.getLatitude(), lastKnownLocation.getLongitude(), results);

                    long[] pattern = new long[] { 20, 50, 100, 200, 40, 100 };
                    vibrator.vibrate(pattern, 1);

                } else {

                    locationManager.removeUpdates(locationListener);
                    vibrator.cancel();

                }
            }
        });
    }

    @Override
    protected void onPause() {
        locationManager.removeUpdates(locationListener);
    }

    View.OnClickListener myhandler1 = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            finish();
        }
    };

}