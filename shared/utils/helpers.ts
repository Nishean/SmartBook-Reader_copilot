export function formatDuration(seconds: number): string {
    const hours = Math.floor(seconds / 3600);
    const minutes = Math.floor((seconds % 3600) / 60);
    const secs = seconds % 60;

    return `${hours > 0 ? hours + 'h ' : ''}${minutes}m ${secs}s`;
}

export function parseMetadata(metadata: string): Record<string, string> {
    const lines = metadata.split('\n');
    const result: Record<string, string> = {};

    lines.forEach(line => {
        const [key, value] = line.split(':').map(part => part.trim());
        if (key && value) {
            result[key] = value;
        }
    });

    return result;
}

export function validateFileType(fileName: string, validTypes: string[]): boolean {
    const fileExtension = fileName.split('.').pop()?.toLowerCase();
    return validTypes.includes(fileExtension || '');
}