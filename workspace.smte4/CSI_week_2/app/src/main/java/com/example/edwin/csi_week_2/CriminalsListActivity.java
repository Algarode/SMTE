package com.example.edwin.csi_week_2;

import android.app.Application;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

/**
 * Created by Edwin on 1-10-2014.
 */
public class CriminalsListActivity extends MainActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.criminalslist);

        ListView lv = (ListView) findViewById(R.layout.lvCriminals);
        final String[] criminals = getResources().getStringArray(R.array.names);
        lv.setAdapter(new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, criminals));
        lv.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                String name = criminals[position];

                Intent intent = new Intent(CriminalsListActivity.this, MainActivity.class);
                intent.putExtra("Name", name);
                startActivity(intent);
            }
        });
    }

}
