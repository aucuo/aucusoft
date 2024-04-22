export function formatValue(value: any): string {
    if (value === undefined || value === null) {
        return "N/A"; // Return "N/A" for undefined and null
    } else if (value instanceof Date) {
        return value.toLocaleDateString();
    } else {
        return value.toString();
    }
}