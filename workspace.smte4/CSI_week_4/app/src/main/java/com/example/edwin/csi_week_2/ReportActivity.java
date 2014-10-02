package com.example.edwin.csi_week_2;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;

/**
 * Created by Edwin on 18-9-2014.
 */
public class ReportActivity extends MainActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.report_activity);
        Button btnBack = (Button) findViewById(R.id.btnBack);
        btnBack.setOnClickListener(myhandler1);
    }

    View.OnClickListener myhandler1 = new View.OnClickListener() {
        @Override
        public void onClick(View view) {
            finish();
        }
    };

}