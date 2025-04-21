// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Function to format and update table values
function updateTableValue(elementId, value) {
    document.getElementById(elementId).innerText = parseFloat(value).toFixed(2);
}

function updateSoilCompositionTable(soilData) {
    soilData.forEach(soil => {
        document.getElementById(`organic-matter-${soil.id}`).innerText = parseFloat(soil.organic_matter).toFixed(2);
        document.getElementById(`pH-${soil.id}`).innerText = parseFloat(soil.pH).toFixed(2);
        document.getElementById(`N-${soil.id}`).innerText = parseFloat(soil.N).toFixed(2);
        document.getElementById(`P-${soil.id}`).innerText = parseFloat(soil.P).toFixed(2);
        document.getElementById(`soil-moisture-${soil.id}`).innerText = parseFloat(soil.soil_moisture).toFixed(2);
    });
}
